using Axa.IntegracaoSistemas.Application.Features.NovoCliente;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Data;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Interfaces;
using BuildingBlocks.Notification;
using BuildingBlocks.Notification.Results;
using Microsoft.AspNetCore.Mvc;

namespace Axa.IntegracaoSistemas.API.Controllers;

[ApiController]
[Tags("cliente")]
public class NovoClienteController : ControllerBase
{
    private readonly ILogger<NovoClienteController> _logger;
    private readonly INovoClienteAppService _novoClienteAppService;
    private readonly NotificationContext _notificationContext;
    private readonly IClienteCustomRepository _clienteCustomRepository;

    public NovoClienteController(
        ILogger<NovoClienteController> logger,
        INovoClienteAppService novoClienteAppService,
        NotificationContext notificationContext,
        IClienteCustomRepository clienteCustomRepository)
    {
        _logger = logger;
        _novoClienteAppService = novoClienteAppService;
        _notificationContext = notificationContext;
        _clienteCustomRepository = clienteCustomRepository;
    }

    [HttpPost("ok")]
    public async Task<IActionResult> PostOk(NovoClienteRequest request)
    {
        _logger.LogInformation("post-ok {Nome}", request.Nome);
        var result = await _novoClienteAppService.PostNovoClienteOkAsync(request);

        return Ok(result);
    }

    [HttpPost("exception")]
    public async Task<IActionResult> PostException(NovoClienteRequest request)
    {
        _logger.LogWarning("Atenção, vai ocorrer um erro! {Id}", Guid.NewGuid());
        var result = await _novoClienteAppService.PostNovoClienteExceptionAsync(request);

        return Ok(result);
    }


    [HttpPost("notificacao-alerta")]
    public async Task<IActionResult> PostAlerta(NovoClienteRequest request)
    {
        _logger.LogInformation("post-notificacao-alerta {Id}", Guid.NewGuid());
        _notificationContext.AddNotification("Alerta1", "Primeiro alerta", true);
        var result = await _novoClienteAppService.PostNovoClienteNotificationAlertaAsync(request);       

        
        return Ok(result);
    }

    [HttpPost("notificacao-erro")]
    public async Task<IActionResult> PostErro(NovoClienteRequest request)
    {
        _logger.LogInformation("post-notificacao-erro {Notifications}", _notificationContext.Notifications);
        var result = await _novoClienteAppService.PostNovoClienteNotificationErroAsync(request);

        return Ok(result);

    }

    [HttpPost("cache")]
    public async Task<IActionResult> PostCache(NovoClienteRequest request)
    {
        var result = await _novoClienteAppService.PostNovoClienteCacheAsync(request);

        return Ok(result);

    }

    [HttpGet("cliente/{id}")]
    public async Task<IActionResult> GetCliente(int id)
    {
        var result = new Result<ClienteCustomDTO> 
        {
            Data = await _clienteCustomRepository.ObterClienteAsync(id)
        };

        return Ok(result);

    }
}