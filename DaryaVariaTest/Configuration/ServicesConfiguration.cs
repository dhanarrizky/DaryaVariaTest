using DaryaVariaTest.IRepositories;
using DaryaVariaTest.Repositories;
using DaryaVariaTest.Services;

namespace DaryaVariaTest.Configuration;

public static class ServicesConfiguration {
    public static IServiceCollection AddConfigurationServices(this IServiceCollection services) {
        // Repositories configuration
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        // services configuration
        services.AddScoped<OrderServices>();
        services.AddScoped<ProductServices>();
        services.AddScoped<ChartServices>();
        services.AddScoped<AuthServices>();
        return services;
    }
}