using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axa.IntegracaoSistemas.Application.Core.Interfaces;

public interface IRequestClient<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    Task<TResponse> ProcessarRequestAsync(TRequest request, CancellationToken cancellationToken = default);
}
