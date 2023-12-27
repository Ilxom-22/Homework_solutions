using Caching.Domain.Common.Caching;
using Caching.Infrastructure.Common.Settings;
using Caching.Persistence.Caching.Brokers;
using Force.DeepCloner;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Caching.Infrastructure.Common.Caching.Brokers;

public class RedisDistributedCacheBroker(IOptions<CacheSettings> cacheSettings, IDistributedCache distributedCache) : ICacheBroker
{
    private readonly DistributedCacheEntryOptions _entryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),
        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };

    public async ValueTask<T?> GetAsync<T>(string key)
    {
        var value = await distributedCache.GetStringAsync(key);

        return value is not null ? JsonConvert.DeserializeObject<T>(value) : default;
    }

    public ValueTask<bool> TryGetAsync<T>(string key, out T? value)
    {
        var foundEntity = distributedCache.GetString(key);

        if (foundEntity is not null)
        {
            value = JsonConvert.DeserializeObject<T>(foundEntity);

            return ValueTask.FromResult(true);
        }

        value = default;
        return ValueTask.FromResult(false);
    }

    public async ValueTask<T?> GetOrSetAsync<T>(string key, Func<Task<T>> valueFactory, CacheEntryOptions? entryOptions = null)
    {
        var cachedValue = await distributedCache.GetStringAsync(key);

        if (cachedValue is not null) return JsonConvert.DeserializeObject<T>(cachedValue);

        var value = await valueFactory();
        await SetAsync(key, value, entryOptions);

        return value;
    }

    public async ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = null)
    {
        await distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), GetCacheEntryOptions(entryOptions));
    }


    public async ValueTask DeleteAsync<T>(string key)
    {
        await distributedCache.RemoveAsync(key);
    }

    public async ValueTask AddCollectionKeyAsync(string key)
    {
        var keys = await distributedCache.GetStringAsync("Keys") ?? string.Empty;
        var cachedEntries = JsonConvert.DeserializeObject<List<string>>(keys) ?? [];

        cachedEntries.Add(key);

        await distributedCache.SetStringAsync("Keys", JsonConvert.SerializeObject(cachedEntries));
    }

    public async ValueTask InvalidateAsync(string entityName)
    {
        var keys = await distributedCache.GetStringAsync("Keys") ?? string.Empty;
        var cachedEntries = JsonConvert.DeserializeObject<List<string>>(keys);

        if (cachedEntries is null) return;

        var entriesToRemove = cachedEntries.Where(entry => entry.StartsWith(entityName)).ToList();

        foreach (var entry in entriesToRemove)
        {
            await distributedCache.RemoveAsync(entry);
            cachedEntries.Remove(entry);
        }

        await distributedCache.SetStringAsync("Keys", JsonConvert.SerializeObject(cachedEntries));
    }

    public DistributedCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? entryOptions)
    {
        if (entryOptions == default || (!entryOptions.AbsoluteExpirationRelativeToNow.HasValue && !entryOptions.SlidingExpiration.HasValue))
            return _entryOptions;

        var currentEntryOptions = _entryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = entryOptions.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = entryOptions.SlidingExpiration;

        return currentEntryOptions;
    }
}