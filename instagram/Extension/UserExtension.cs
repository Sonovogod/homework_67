using instagram.Models;
using instagram.Services.ViewModels.Users;
using instagram.ViewModels.Users;

namespace instagram.Extension;

public static class UserExtension
{
    public static User MapToUserModel(this UserRegisterViewModel model)
    {
        return new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            Avatar = model.Avatar,
            Name = model.Name,
            UserInfo = model.UserInfo,
            PhoneNumber = model.PhoneNumber,
            Gender = model.Gender
        };
    }
    
    public static UserProfileViewModel MapToUserProfileViewModel(this User model)
    {
        UserProfileViewModel newModel = new UserProfileViewModel()
        {
            UserName = model.UserName,
            Email = model.Email,
            Avatar = model.Avatar,
            Name = model.Name,
            UserInfo = model.UserInfo,
            PhoneNumber = model.PhoneNumber,
            Posts = model.Posts.MapToPostViewModel(),
            Followers = model.Followers.MapToFollowerViewModel(),
            Subscriptions = model.Subscriptions.MapToSubscriptionViewModel()
        };
        return newModel;
    }
    public static UserShortViewModel MapToUserShortViewModel(this User model)
    {
        return new UserShortViewModel()
        {
            Avatar = model.Avatar,
            Id = model.Id,
            UserName = model.UserName
        };
    }
    
    public static UserViewModel MapToUserViewModel(this User model)
    {
        return new UserViewModel()
        {
            Avatar = model.Avatar,
            Id = model.Id,
            UserName = model.UserName,
            Name = model.Name,
            UserInfo = model.UserInfo,
            DateOfCreate = model.DateOfCreate
        };
    }

    public static List<SubscribersViewModel> MapToSubscribersViewModel(this IEnumerable<User> model)
    {
        List<SubscribersViewModel> subscribersViewModels = model.Select(x => new SubscribersViewModel()
        {
            Id = x.Id,
            Avatar = x.Avatar,
            UserName = x.UserName
        }).ToList();
        return subscribersViewModels;
    }
    
    public static List<UserSearchViewModel> MapToUserResultProfile(this IEnumerable<User> model)
    {
        List<UserSearchViewModel> UserResultProfile = model.Select(x => new UserSearchViewModel()
        {
            Avatar = x.Avatar,
            UserName = x.UserName,
            UserInfo = x.UserInfo,
            Followers = x.Followers.MapToFollowerViewModel()
        }).ToList();
        return UserResultProfile;
    }
    public static List<UserMiddleViewModel> MapToUserSortResultViewModel(this IEnumerable<User> model)
    {
        List<UserMiddleViewModel> UserResultProfile = model.Select(x => new UserMiddleViewModel()
        {
            Avatar = x.Avatar,
            UserName = x.UserName,
            UserInfo = x.UserInfo,
            Followers = x.Followers.MapToFollowerViewModel(),
            Subscriptions = x.Subscriptions.MapToSubscriptionViewModel()
        }).ToList();
        return UserResultProfile;
    }
    
    public static List<FollowerViewModel> MapToFollowerViewModel(this IEnumerable<UserFollower> model)
    {
        List<FollowerViewModel> newModel = model.Select(x => new FollowerViewModel()
        {
            Id = x.Id,
            UserId = x.UserId,
            User = x.User.MapToUserViewModel(),
            FollowerId = x.FollowerId,
            DateOfFollowing = x.DateOfFollowing
        }).ToList();
        return newModel;
    }
    
    public static List<SubscriptionViewModel> MapToSubscriptionViewModel(this IEnumerable<UserSubscription> model)
    {
        List<SubscriptionViewModel> newModel = model.Select(x => new SubscriptionViewModel()
        {
            Id = x.Id,
            UserId = x.UserId,
            User = x.User.MapToUserViewModel(),
            SubscriptionId = x.SubscriptionId,
            DateOfSubscription = x.DateOfSubscription
        }).ToList();
        return newModel;
    }
}