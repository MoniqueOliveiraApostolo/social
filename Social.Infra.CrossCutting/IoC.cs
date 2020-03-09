using Microsoft.Extensions.DependencyInjection;
using Social.Domain.Interfaces;
using Social.Infra.Data.Repository;
using Social.Service.Services;

namespace Social.Infra.CrossCutting
{
    public static class IoC
    {
        public static IServiceCollection ResolveApi(this IServiceCollection service){

            service
            .AddScoped<IContatoService, ContatoService>()
            .AddScoped<IContatoRepository, ContatoRepository>();
            
            return service;
        }
    }
}
