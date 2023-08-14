public class ReviewList<TReview> : IReviewList<TReview> where TReview : class, IReview
{
    private List<TReview> _reviewList;

    public ReviewList()
    {
        _reviewList = new List<TReview>();
    }


    public void Add(TReview item)
    {
        _reviewList.Add(item);
    }

    public void GetOverallReview()
    {
        if (!_reviewList.Any())
        {
            Console.WriteLine("Be the first to leave a review for this product.");
            return;
        }

        if (_reviewList.All(item => item.Star == 5))
        {
            Console.WriteLine("Great news! All reviews for this product are 5-star ratings.");
            return;
        }

        var review = _reviewList.FirstOrDefault(item => item.Star == 1);
        if (review != null)
            Console.WriteLine(review.Message);
    }

    public TReview? GetReview(Guid id)
    {
        var item = _reviewList.FirstOrDefault(x => x.Id == id);
        return item;
    }

    public TReview? GetReview(string message)
    {
        var item = _reviewList.Find(item => item.Message == message);
        return item;
    }

    public void Remove(Guid id)
    {
        var item = _reviewList.FirstOrDefault(x => x.Id == id);
        if (item == null)
            return;

        _reviewList.Remove(item);
    }

    public void Remove(TReview item)
    {
        _reviewList.Remove(item);
    }

    public void Update(Guid id, byte star, string message)
    {
        var updateReview = _reviewList.FirstOrDefault(review => review.Id == id);

        if (updateReview == null)
            return;

        updateReview.Star = star;
        updateReview.Message = message;
    }
}

