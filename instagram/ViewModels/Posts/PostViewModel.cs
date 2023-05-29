using instagram.Models;
using instagram.Services.ViewModels.Users;
using instagram.ViewModels.Comments;
using instagram.ViewModels.Likes;

namespace instagram.Services.ViewModels.Posts;

public class PostViewModel
{
    public int Id { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string ImgPath { get; set; }
    public string? Content { get; set; }
    public List<LikeViewModel>? Likes { get; set; }
    public List<CommentViewModel>? Comments { get; set; }
    public string CreatorId { get; set; }
    public UserViewModel Creator { get; set; }
}