public class PostRating
{
    public Guid PostId { get; set; }
    public Guid UserId { get; set; }
    public bool IsLike { get; set; }

    public PostRating(Guid postId, Guid userId, bool isLike)
    {
        PostId = postId;
        UserId = userId;
        IsLike = isLike;
    }
}