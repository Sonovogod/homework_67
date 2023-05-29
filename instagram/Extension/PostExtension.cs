using instagram.Models;
using instagram.Services.ViewModels.Posts;
using instagram.ViewModels.Comments;
using instagram.ViewModels.Likes;

namespace instagram.Extension;

public static class PostExtension
{
    public static Post PostExtensionViewModel(this PostCreateViewModel model)
    {
        return new Post()
        {
            ImgPath = model.ImgPath,
            Content = model.Content
        };
    }

    public static List<Post> MapToSubscribePosts(this IEnumerable<User> model)
    {
        List<Post> posts = new List<Post>();
        foreach (var user in model)
        {
            posts.AddRange(user.Posts);
        }
        return posts.OrderByDescending(x => x.DateOfCreate).ToList();
    }

    public static List<PostViewModel> MapToPostViewModel(this IEnumerable<Post> model)
    {
        List<PostViewModel> postViewModel = model.Select(x => new PostViewModel()
        {
            Comments = x.Comments.MapToCommentViewModels(),
            Content = x.Content,
            DateOfCreate = x.DateOfCreate,
            Id = x.Id,
            ImgPath = x.ImgPath,
            Likes = x.Likes.MapToLikeViewModels(),
            CreatorId = x.CreatorId,
            Creator = x.Creator.MapToUserViewModel()
        }).ToList();
        return postViewModel;
    }
    
    public static PostViewModel MapToPostViewModel(this Post model)
    {
        return new PostViewModel()
        {
            Comments = model.Comments.MapToCommentViewModels(),
            Content = model.Content,
            Creator = model.Creator.MapToUserViewModel(),
            CreatorId = model.CreatorId,
            DateOfCreate = model.DateOfCreate,
            Id = model.Id,
            ImgPath = model.ImgPath,
            Likes = model.Likes.MapToLikeViewModels()
        };
    }

    public static List<LikeViewModel> MapToLikeViewModels(this IEnumerable<Like> model)
    {
        List<LikeViewModel> likeViewModels = model.Select(x => new LikeViewModel()
        {
            Id = x.Id,
            DateOfLiked = x.DateOfLiked,
            PostId = x.PostId,
            UserId = x.UserId
        }).ToList();

        return likeViewModels;
    }
    
    public static List<CommentViewModel> MapToCommentViewModels(this IEnumerable<Comment> model)
    {
        List<CommentViewModel> likeViewModels = model.Select(x => new CommentViewModel()
        {
            Id = x.Id,
            Content = x.Content,
            DateOfCreat = x.DateOfCreat,
            Commentator = x.Commentator.MapToUserShortViewModel(),
            PostId = x.PostId,
            CommentatorId = x.CommentatorId,
        }).ToList();

        return likeViewModels;
    }
}