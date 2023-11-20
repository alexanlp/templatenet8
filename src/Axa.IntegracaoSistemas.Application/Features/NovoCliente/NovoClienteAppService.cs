
using Axa.IntegracaoSistemas.Application.Core.Extensions;
using Axa.IntegracaoSistemas.Application.Core.Interfaces;
using Axa.IntegracaoSistemas.Application.Options.Application.Core.Options;
using BuildingBlocks.Notification;
using BuildingBlocks.Notification.Results;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Axa.IntegracaoSistemas.Application.Features.NovoCliente;

public class NovoClienteAppService : INovoClienteAppService
{
    private readonly IRequestClient<NovoClienteDTORequest, NovoClienteDTOResponse> _requestClient;
    private readonly NotificationContext _notificationContext;
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<NovoClienteAppService> _logger;
    private readonly List<CacheConfigurationOptions> _cacheConfiguration;

    public NovoClienteAppService(
        IRequestClient<NovoClienteDTORequest, NovoClienteDTOResponse> requestClient,
        NotificationContext notificationContext,
        IMemoryCache memoryCache,
        ILogger<NovoClienteAppService> logger,
        IOptionsSnapshot<List<CacheConfigurationOptions>> cacheConfiguration)
    {
        _requestClient = requestClient;
        _notificationContext = notificationContext;
        _memoryCache = memoryCache;
        _logger = logger;
        _cacheConfiguration = cacheConfiguration.Value;
    }

    public async Task<Result<NovoClienteResponse>> PostNovoClienteCacheAsync(NovoClienteRequest request)
    {
        Result<NovoClienteResponse> result = null;

        // Checagem se o token está no cache
        if (_memoryCache.TryGetValue(CacheKeysExtension.CACHE_ID, out result))
        {
            _logger.LogInformation("Result recuperado do cache Id: {Id}", result.Data.Id);
            return await Task.FromResult(result);            
        }
        
        result = new Result<NovoClienteResponse> { Data = new NovoClienteResponse { Id = Guid.NewGuid().ToString(), Nome = request.Nome } };
        _memoryCache.SetData(CacheKeysExtension.CACHE_ID, result, _cacheConfiguration, CacheKeysExtension.CHAVE_CACHE_NOVO_CLIENTE_TIMEOUT_TOKEN);
        
        return await Task.FromResult(result);
    }

    public async Task<Result<NovoClienteResponse>> PostNovoClienteExceptionAsync(NovoClienteRequest request)
    {
        await Task.Run(() => throw new Exception("Exemplo de erro ao processar request"));
        
        return Task.FromResult(new Result<NovoClienteResponse> { Data = new NovoClienteResponse { Id = Guid.NewGuid().ToString(), Nome = request.Nome } }).Result;
    }

    public async Task<Result<NovoClienteResponse>> PostNovoClienteNotificationAlertaAsync(NovoClienteRequest request)
    {
        var dtoRequest = new NovoClienteDTORequest(request.Nome);
        var result = await _requestClient.ProcessarRequestAsync(dtoRequest);
        _notificationContext.AddNotification("Alerta2", "Segundo alerta", true);
        _notificationContext.AddNotification("Alerta3", "Terceiro Alerta", true);

        return await Task.FromResult(new Result<NovoClienteResponse>
        {
            Data = new NovoClienteResponse
            {
                Id = "1",
                Nome = request.Nome
            },
            Messages = _notificationContext.Notifications.Select(x => x.Message).ToList()
        });
    }

    public async Task<Result<NovoClienteResponse>> PostNovoClienteNotificationErroAsync(NovoClienteRequest request)
    {
        var dtoRequest = new NovoClienteDTORequest(request.Nome);
        var result = await _requestClient.ProcessarRequestAsync(dtoRequest);
        _notificationContext.AddNotification("Notificação de erro depois da chamada ao serviço externo");

        return await Task.FromResult(new Result<NovoClienteResponse> { Data = new NovoClienteResponse { Id = result.id, Nome = result.nome } });
    }

    public async Task<Result<NovoClienteResponse>> PostNovoClienteOkAsync(NovoClienteRequest request)
    {
        var dtoRequest = new NovoClienteDTORequest(request.Nome);
        
        var result = await _requestClient.ProcessarRequestAsync(dtoRequest);

        return await Task.FromResult(new Result<NovoClienteResponse> { Data = new NovoClienteResponse { Id = result.id, Nome = result.nome } });
    }
}
