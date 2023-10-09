using EPiServer;
using EPiServer.Core;
using EPiServer.Web.Routing;
using Imazen.Common.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Alsterverse.Imageflow.Optimizely
{
    public class OptimizelyBlobService : IBlobProvider
    {
        private readonly OptimizelyBlobServiceOptions options;
        private readonly ILogger<OptimizelyBlobService> logger;
        private readonly UrlResolver urlResolver;

        public OptimizelyBlobService(IOptions<OptimizelyBlobServiceOptions> options, ILogger<OptimizelyBlobService> logger, UrlResolver urlResolver)
        {
            this.options = options.Value;
            this.logger = logger;
            this.urlResolver = urlResolver;
        }

        public IEnumerable<string> GetPrefixes() => options.Prefixes;

        public bool SupportsPath(string virtualPath) => options.Prefixes.Any(p => virtualPath.StartsWith(p, options.IgnorePrefixCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal));

        public Task<IBlobData> Fetch(string virtualPath)
        {
            var content = urlResolver.Route(new UrlBuilder(virtualPath));
            var binaryStorable = content as IBinaryStorable;
            return Task.FromResult<IBlobData>(new OptimizelyBlobData(binaryStorable));
        }
    }
}
