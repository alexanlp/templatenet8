using System.Data;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Data;
using Axa.IntegracaoSistemas.Domain.CustomRepositories.Interfaces;
using Axa.IntegracaoSistemas.Infraestructure.Repositories.Abstract;

namespace Axa.IntegracaoSistemas.Infraestructure.Repositories;

public class ClienteCustomRepository : SqlServerDatabaseContext, IClienteCustomRepository
{
    public ClienteCustomRepository(IDbConnection connection, bool useQuotationMarks = false) 
        : base(connection, useQuotationMarks)
    {
    }

    public async Task<ClienteCustomDTO> ObterClienteAsync(int idCliente, CancellationToken cancellationToken = default)
    {
        return await Task.FromResult(new ClienteCustomDTO
        {
            IdCliente = idCliente,
            Nome = "Cliente 1",
            Enderecos = new List<EnderecoDTO>
            {
                new EnderecoDTO
                {
                    CEP = "00000-000"
                },
                new EnderecoDTO
                {
                    CEP = "11111-111"
                }
            }
        });
    }
}
