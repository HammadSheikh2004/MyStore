using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Column("customerName")]
        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer Name is Required!")]
        public string CustomerName { get; set; } = string.Empty;
        [Column("customerEmail")]
        [DisplayName("Customer Email")]
        [Required(ErrorMessage = "Customer Email is Required!")]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
