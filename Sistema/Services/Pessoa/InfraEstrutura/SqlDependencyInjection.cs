using Dominio.Repositorios;
using InfraEstrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace InfraEstrutura;

public static class SqlDependencyInjection
{
    public static IServiceCollection AddSqlServices(this IServiceCollection services)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();

        return services;
    }
}
