using Axa.IntegracaoSistemas.Application.Core.Interfaces;
using Axa.IntegracaoSistemas.Application.Features.NovoCliente;
using Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;
using BuildingBlocks.Notification;
using Microsoft.Extensions.Logging;

namespace Axa.IntegracaoSistemas.Infraestructure.ClientApi.NumeroApolice;

public class NovoClienteClient :
    HttpClientBase<NovoClienteDTORequest, NovoClienteDTOResponse, NovoClienteClient>,
    IRequestClient<NovoClienteDTORequest, NovoClienteDTOResponse>
{
    private const string RESOURCE = "resource/{user}";

    public NovoClienteClient(
        ILogger<NovoClienteClient> logger, 
        HttpClient httpClient, 
        NotificationContext notificationContext) 
            : base(logger, httpClient, notificationContext)
    {
    }

    public async Task<NovoClienteDTOResponse> ProcessarRequestAsync(NovoClienteDTORequest request, CancellationToken cancellationToken = default)
    {
        // Sempre implementar como async esse método
        // Implementar chamada ao serviço externo
        // Exemplo extraído de um projeto real
            // var requestMessage = new HttpRequestMessage(HttpMethod.Get, string.Format(RESOURCE, request.user));
            // var response = await SendAsync(request, requestMessage, "Erro ao consultar cotação de Imobiliário", cancellationToken);
            // return response;

        return await Task.FromResult(new NovoClienteDTOResponse("1", request.nome));
    }
}
