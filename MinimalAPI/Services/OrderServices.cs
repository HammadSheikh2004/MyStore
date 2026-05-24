using Microsoft.EntityFrameworkCore;
using MinimalAPI.DbContextClass;
using MinimalAPI.DTOs;
using MinimalAPI.Models;
using MinimalAPI.Repository;

namespace MinimalAPI.Services
{
    public class OrderServices : IOrderRepository
    {
        private readonly MyDbContext _context;
        public OrderServices(MyDbContext context)
        {
            this._context = context;
        }
        public async Task<OrderDTO> InsertOrder(OrderDTO orderDTO)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (orderDTO == null || orderDTO.OrderItems == null || !orderDTO.OrderItems.Any())
                {
                    throw new Exception("Invalid Order!");
                }

                var order = new Order
                {
                    CustomerName = orderDTO.CustomerName,
                    CustomerEmail = orderDTO.CustomerEmail
                };

                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                foreach (var item in orderDTO.OrderItems)
                {
                    var product = await _context.Products
                        .Where(x => x.ProductId == item.ProductId).FirstOrDefaultAsync();

                    if (product == null)
                        throw new Exception($"Product not found: {item.ProductId}");

                    if (product.ProductQuanity < item.ProductQuantity)
                        throw new Exception($"Insufficient stock for product: {product.ProductName}");

                    product.ProductQuanity -= item.ProductQuantity;

                    var orderItem = new OrderItems
                    {
                        ProductId = product.ProductId,
                        Quanity = item.ProductQuantity,
                        OrderId = order.OrderId,
                        Price = product.ProductPrice
                    };

                    orderItem.CalculateTotalPrice();

                    await _context.OrderItems.AddAsync(orderItem);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return orderDTO;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Error occurred", ex);
            }
        }
    }
}
