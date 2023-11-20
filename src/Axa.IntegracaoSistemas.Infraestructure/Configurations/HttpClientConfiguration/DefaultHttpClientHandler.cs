using System.Net;

namespace Axa.IntegracaoSistemas.Infraestructure.Configurations.HttpClientConfiguration;

public class DefaultHttpClientHandler : HttpClientHandler
{
    public DefaultHttpClientHandler() =>
        this.AutomaticDecompression = DecompressionMethods.Brotli | DecompressionMethods.Deflate | DecompressionMethods.GZip;
}
