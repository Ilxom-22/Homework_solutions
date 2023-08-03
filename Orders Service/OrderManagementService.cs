public class OrderManagementService
{
    private readonly List<int> _orders;
    private OrderCacheService _cache;



    public OrderManagementService()
    {
        _orders = new List<int>();
        _cache = OrderCacheService.GetInstance();
    }



    public void Add(int amount)
    {
        if (amount < 1)
            throw new ArgumentOutOfRangeException(nameof(amount), "Invalid amount!");

        _orders.Add(amount);
    }



    public int Max()
    {
        string key = CacheKeyConstans.Max(_orders);
        var max = _cache.Get(key);

        if (max == default)
        {
            foreach (var item in _orders)
                if (max < item)
                    max = item;

            _cache.Set(key, max);
        }

        return max;
    }



    public int Min()
    {
        string key = CacheKeyConstans.Min(_orders);
        var min = _cache.Get(key);

        if (min == default)
        {
            min = int.MaxValue;
            foreach (var item in _orders)
                if (min > item)
                    min = item;

            _cache.Set(key, min);
        }

        return min;
    }



    public int Sum()
    {
        string key = CacheKeyConstans.Sum(_orders);
        var sum = _cache.Get(key);

        if (sum == default)
        {
            foreach (var item in _orders)
                sum += item;

            _cache.Set(key, sum);
        }

        return sum;
    }
}   