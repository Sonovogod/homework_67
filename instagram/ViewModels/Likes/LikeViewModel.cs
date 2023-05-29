namespace instagram.ViewModels.Likes;

public class LikeViewModel
{
    public int Id { get; set; }
    public DateTime DateOfLiked { get; set; }
    public int PostId { get; set; }
    public string UserId { get; set; }
}