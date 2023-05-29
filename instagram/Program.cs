using System.IO.Compression;
using instagram.Extension;
using instagram.Models;
using instagram.Services;
using instagram.Services.Abstracts;
using instagram.Services.File;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<InstagramContext>(options => options.UseNpgsql(connection))
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<InstagramContext>();

builder.Services.AddResponseCompression(options => options.EnableForHttps = true);
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Optimal;
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IImageProfile, LogoImageProfile>();
builder.Services.AddScoped<IImageProfile, PostImageProfile>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IMemoryCache, MemoryCache>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseResponseCompression();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Feed}/{id?}");

app.Run();