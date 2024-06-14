using Microsoft.Extensions.Caching.Distributed;

namespace GydraAPI.RedisContainer;

public class RedisCache<T>(IDistributedCache cache)
{
    public async Task SetData(byte[] data, string key) => await cache.SetAsync(key, data);
    
    public async Task<byte[]?> GetData( string key) => await cache.GetAsync(key);
}