namespace instagram.Services.ViewModels.Users;

public class FollowerViewModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserViewModel User { get; set; }
    public string FollowerId { get; set; }
    public UserViewModel Follower { get; set; }
    public DateTime DateOfFollowing { get; set; }
}