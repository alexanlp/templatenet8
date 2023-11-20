using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axa.IntegracaoSistemas.Domain.CustomRepositories.Data;

public class ClienteCustomDTO
{
    public int IdCliente { get; set; }
    public string Nome { get; set; }
    public List<EnderecoDTO> Enderecos { get; set; }
}

public class EnderecoDTO
{
    public string CEP { get; set; }
}
