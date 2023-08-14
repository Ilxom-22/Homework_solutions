public interface IReviewList<TReview> where TReview : IReview
{
    void Add(TReview item);
    void Update(Guid id, byte star, string message);
    void Remove(Guid id);
    void Remove(TReview item);
    TReview GetReview(Guid id);
    TReview GetReview(string message);
    void GetOverallReview();
}
