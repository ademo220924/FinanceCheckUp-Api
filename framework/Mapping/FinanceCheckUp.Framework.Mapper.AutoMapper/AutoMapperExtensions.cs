using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceCheckUp.Framework.Mapper.AutoMapper;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperRegistration(this IServiceCollection services, MapperConfiguration mappingConfiguration)
    {
        var mapper = mappingConfiguration.CreateMapper();
        services.AddSingleton(mapper);
        services.AddSingleton<IFinanceCheckUpMapper, FinanceCheckUpMapper>();
        return services;
    }
}