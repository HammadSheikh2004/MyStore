using MinimalAPI.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.DTOs
{
    public class OrderDTO
    {
        public int OrdersId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;

        public List<OrderItemsDTO> OrderItems { get; set; } = new List<OrderItemsDTO>();
    }
}
