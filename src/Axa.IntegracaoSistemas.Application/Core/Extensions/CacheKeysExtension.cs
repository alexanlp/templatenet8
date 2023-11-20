using Axa.IntegracaoSistemas.Application.Options.Application.Core.Options;

namespace Axa.IntegracaoSistemas.Application.Core.Extensions;

public static class CacheKeysExtension
{
    // Coloque aqui as chaves de cache e chaves de configuração de cache do appSettings.json,
    //  Por exemplo: 
        public const string CONFIG_CACHE_SeguradoraXPTO_API = "SeguradoraXPTO:CacheConfiguration";    
        public const string CACHE_ID = "cache-id";
        public const string CHAVE_CACHE_NOVO_CLIENTE_TIMEOUT_TOKEN = "CacheTokenNovoCliente";
    //    
    //    No appSettings.json:
    //      "SeguradoraXPTO": {
    //          "BaseAddress": "https://seguradoraxpto.com.br",
    //          "Timeout": "00:00:30",
    //          "CacheConfiguration": [
    //              {
    //                  "Name": "CacheTokenNovoCliente",
    //                  "Timeout": "00:30:00",
    //                  "Enabled": true
    //              }
    //          ]
    //      } 

    public static TimeSpan GetTimeOut(this List<CacheConfigurationOptions> options, string chave)
    {
        var cacheConfiguration = options.FirstOrDefault(x => x.Name == chave);
        if (cacheConfiguration is null) return TimeSpan.Zero;
        if (!cacheConfiguration.Enabled) return TimeSpan.Zero;

        return cacheConfiguration?.Timeout ?? TimeSpan.Zero;
    }
}
