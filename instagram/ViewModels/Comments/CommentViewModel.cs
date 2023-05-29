using instagram.Services.ViewModels.Posts;
using instagram.Services.ViewModels.Users;

namespace instagram.ViewModels.Comments;

public class CommentViewModel
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime DateOfCreat { get; set; }

    public string CommentatorId { get; set; }
    public UserShortViewModel? Commentator { get; set; }
    public int PostId { get; set; }
    public PostViewModel Post { get; set; }
}