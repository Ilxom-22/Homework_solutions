public interface IReview
{
    public Guid Id { get; set; }
    public byte Star { get; set; }
    public string Message { get; set; }
}