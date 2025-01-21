using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Repositories;
using DaryaVariaTest.Services;

namespace DaryaVariaTest.Configuration;

public static class ServicesConfiguration {
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services) {
        // Repositories configuration
        services.AddScoped<IOrderRepository, OrderRepository>();

        // services configuration
        services.AddScoped<OrderServices>();
        return services;
    }
}