using MinimalAPI.EndPoints;

namespace MinimalAPI.CollectionExtension
{
    public static class EndpointsCollectionExtension
    {
        public static IEndpointRouteBuilder APIEndpointsCollection(this IEndpointRouteBuilder routes)
        {
            routes.ProductAPI();
            routes.OrderAPI();

            return routes;
        }
    }
}
