public class OrderCacheService
{
    private readonly Dictionary<string, int> _cacheValues = new Dictionary<string, int>();
    private static OrderCacheService _instance;
    private OrderCacheService()
    {
    }

    public static OrderCacheService GetInstance()
    {
        if (_instance == null)
            _instance = new OrderCacheService();

        return _instance;
    }



    public int Get(string key)
    {
        if (_cacheValues.ContainsKey(key))
            return _cacheValues[key];

        return default(int);
    }



    public void Set(string key, int value)
    {
        if (!_cacheValues.ContainsKey(key))
            _cacheValues[key] = value;
    }
}