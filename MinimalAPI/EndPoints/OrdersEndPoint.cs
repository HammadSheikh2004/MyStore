using MinimalAPI.DTOs;
using MinimalAPI.Repository;

namespace MinimalAPI.EndPoints
{
    public static class OrdersEndPoint
    {
        public static void OrderAPI(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/orderInsert", async (IOrderRepository orderRepo, OrderDTO orderDTO) =>
            {
                try
                {
                    var order = await orderRepo.InsertOrder(orderDTO);
                    if (order == null)
                    {
                        return Results.BadRequest(new { errorMessage = "Orders are null" });
                    }
                    return Results.Ok(new { successMessage = "You Placed Order Successfully!", data = order });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { errorMessage = ex.Message });
                }

            });
        }
    }
}
