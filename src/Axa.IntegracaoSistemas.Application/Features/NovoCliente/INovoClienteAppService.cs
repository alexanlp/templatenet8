using BuildingBlocks.Notification.Results;

namespace Axa.IntegracaoSistemas.Application.Features.NovoCliente;

public interface INovoClienteAppService
{
    Task<Result<NovoClienteResponse>> PostNovoClienteOkAsync(NovoClienteRequest request);
    Task<Result<NovoClienteResponse>> PostNovoClienteNotificationAlertaAsync(NovoClienteRequest request);
    Task<Result<NovoClienteResponse>> PostNovoClienteNotificationErroAsync(NovoClienteRequest request);
    Task<Result<NovoClienteResponse>> PostNovoClienteExceptionAsync(NovoClienteRequest request);
    Task<Result<NovoClienteResponse>> PostNovoClienteCacheAsync(NovoClienteRequest request);
}
