using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Data;

namespace Axa.IntegracaoSistemas.Domain.CustomRepositories.Interfaces;

public interface IClienteCustomRepository
{
    Task<ClienteCustomDTO> ObterClienteAsync(int idCliente, CancellationToken cancellationToken = default);
}
