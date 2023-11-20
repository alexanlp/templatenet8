using Axa.IntegracaoSistemas.Application.Options.Application.Core.Options;
using Microsoft.Extensions.Caching.Memory;

namespace Axa.IntegracaoSistemas.Application.Core.Extensions;

public static class MemoryCacheExtension
{
    public static void SetData<TData>(
        this IMemoryCache memoryCache,
        string chaveCache,
        TData data,
        List<CacheConfigurationOptions> cacheConfiguration,
        string chaveTimeout)
    {
        var timeOut = cacheConfiguration.GetTimeOut(chaveTimeout);
        if (timeOut == TimeSpan.Zero) return;

        memoryCache.Set(chaveCache, data, timeOut);
    }
}
