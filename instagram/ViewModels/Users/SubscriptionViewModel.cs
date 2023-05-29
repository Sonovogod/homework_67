namespace instagram.Services.ViewModels.Users;

public class SubscriptionViewModel
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public UserViewModel User { get; set; }
    public string SubscriptionId { get; set; }
    public UserViewModel Subscription { get; set; }
    public DateTime DateOfSubscription { get; set; }
}