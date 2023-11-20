using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Axa.IntegracaoSistemas.Application.Options.Application.Core.Options;

public class RetryPolicyOptions
{
    public int BackoffPower { get; set; }
    public int Count { get; set; }
}

public class HttpClientOptions
{
    public Uri? BaseAddress { get; set; }
    public TimeSpan Timeout { get; set; }
}

public class CacheConfigurationOptions
{
    public string? Name { get; set; }
    public TimeSpan Timeout { get; set; }
    public bool Enabled { get; set; }
}
