using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axa.IntegracaoSistemas.Application.Core.Extensions;

public static class DecimalExtension
{
    public static decimal ToDecimal(this int? valor)
    {
        if (valor is null)
            return 0;

        return (decimal)valor / 100;
    }

    public static decimal ToDecimal(this int valor)
    {
        return (decimal)valor / 100;
    }

}
