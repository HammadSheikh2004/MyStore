using MinimalAPI.DTOs;

namespace MinimalAPI.Repository
{
    public interface IOrderRepository
    {
        public Task<OrderDTO> InsertOrder(OrderDTO orderDTO);
        public Task<IEnumerable<PlacedOrderDTO>> GetPlacedOrders();
    }
}
