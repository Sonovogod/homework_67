using instagram.Services.ViewModels.Posts;

namespace instagram.Services.ViewModels.Users;

public class UserViewModel
{
    public string Id { get; set; }
    public string Avatar { get; set; }
    public string? Name { get; set; }
    public string? UserInfo { get; set; }
    public string UserName { get; set; }
    public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
    public List<FollowerViewModel> Followers { get; set; } = new List<FollowerViewModel>();
    public List<SubscriptionViewModel> Subscriptions { get; set; } = new List<SubscriptionViewModel>();
    public DateTime DateOfCreate { get; set; }
}