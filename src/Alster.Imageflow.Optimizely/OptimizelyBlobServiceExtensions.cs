using Imazen.Common.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Alsterverse.Imageflow.Optimizely
{
    public static class OptimizelyBlobServiceExtensions
    {
        public static IServiceCollection AddImageflowOptimizelyBlobService(this IServiceCollection services,
            Action<OptimizelyBlobServiceOptions> options = default)
        {
            options ??= _ => { };

            services.Configure(options);
            services.AddSingleton<IBlobProvider, OptimizelyBlobService>();
            return services;
        }
    }
}
