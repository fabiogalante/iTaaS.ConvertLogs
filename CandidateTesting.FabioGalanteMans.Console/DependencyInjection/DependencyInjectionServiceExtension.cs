using CandidateTesting.FabioGalanteMans.Console.Services.File;
using CandidateTesting.FabioGalanteMans.Console.Services.Rest;
using CandidateTesting.FabioGalanteMans.Console.Services.Split;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTesting.FabioGalanteMans.Console.DependencyInjection
{
    public static class DependencyInjectionServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<IRestService, RestService>();
            service.AddScoped<ISplitService, SplitService>();
            service.AddScoped<IFileService, FileService>();
            return service;
        }
    }
}
