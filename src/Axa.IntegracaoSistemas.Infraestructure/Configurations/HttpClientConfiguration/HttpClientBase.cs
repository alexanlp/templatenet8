using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BuildingBlocks.Notification;
using Microsoft.Extensions.Logging;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;

public abstract class HttpClientBase<TRequest, TResult, TClient> where TClient : class
{
    protected readonly ILogger<TClient> _logger;
    protected readonly HttpClient _httpClient;
    private readonly NotificationContext _notificationContext;
    public HttpClientBase(
        ILogger<TClient> logger,
        HttpClient httpClient,
        NotificationContext notificationContext)
    {
        _logger = logger;
        _httpClient = httpClient;
        _notificationContext = notificationContext;
    }
    protected async virtual Task<TResult> SendAsync(TRequest request, HttpRequestMessage requestMessage, string? errorMessage = null, CancellationToken cancellationToken = default)
    {
        requestMessage = await SetSendOptionsAsync(request, requestMessage);
        var response = await _httpClient.SendAsync(requestMessage);

        if ((int)response.StatusCode >= (int)HttpStatusCode.InternalServerError)
        {
            _notificationContext.AddNotification($"{errorMessage}: {requestMessage.RequestUri} - {response.StatusCode}");
            _logger.LogError($"HttpRequest: {errorMessage}: {requestMessage.RequestUri} - {response.StatusCode}");
        }

        var result = await response.Content.ReadFromJsonAsync<TResult>(cancellationToken: cancellationToken);
        return result;
    }

    protected async virtual Task<HttpRequestMessage> SetSendOptionsAsync(TRequest request, HttpRequestMessage requestMessage)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        requestMessage.Content = new StringContent(JsonSerializer.Serialize(request, options), Encoding.UTF8, "application/json");

        return await Task.FromResult(requestMessage);
    }
}
