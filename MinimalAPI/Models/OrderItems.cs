using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Models
{
    [Table("OrderItems")]
    public class OrderItems
    {
        [Key]
        public int OrderItemId { get; set; }
        [Column("productPrice", TypeName = "decimal(18, 2)")]
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Prodcut Price is Required!")]
        public decimal Price { get; set; }
        [Column("productQuantity")]
        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "Prodcut Quantity is Required!")]
        public int Quanity { get; set; }
        [Column("totalPrice", TypeName = "decimal(18, 2)")]
        [DisplayName("Total Price")]
        [Required(ErrorMessage = "Total Price is Required!")]
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public Products? Products { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }
        public decimal CalculateTotalPrice()
        {
            return this.TotalPrice = this.Quanity * this.Price;
        }
    }
}
