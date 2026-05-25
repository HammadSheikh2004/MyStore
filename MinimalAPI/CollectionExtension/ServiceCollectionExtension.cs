using MinimalAPI.Repository;
using MinimalAPI.Services;

namespace MinimalAPI.CollectionExtension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection APIServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductService>();
            services.AddScoped<IOrderRepository, OrderServices>();
            return services;
        }
    }
}
