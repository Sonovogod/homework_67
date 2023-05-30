using System.ComponentModel.DataAnnotations;
using instagram.Services.ViewModels.Posts;
using instagram.Services.ViewModels.Users;

namespace instagram.ViewModels.Users;

public class UserProfileViewModel
{
    public string Avatar { get; set; }
    public string? Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? UserInfo { get; set; }
    public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    public List<FollowerViewModel> Followers { get; set; } = new List<FollowerViewModel>();
    public List<SubscriptionViewModel> Subscriptions { get; set; } = new List<SubscriptionViewModel>();
    [MaxLength(2200, ErrorMessage = "Не более 2200 симоволов")]
    [Display(Name = "Описание")]
    public string? Content { get; set; }
}