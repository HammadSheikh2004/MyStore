using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Column("productName")]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Prodcut Name is Required!")]
        public string ProductName { get; set; } = string.Empty;
        [Column("productDescription")]
        [DisplayName("Product Description")]
        public string ProductDescription { get; set; } = string.Empty;
        [Column("productPrice", TypeName = "decimal(18, 2)")]
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Prodcut Price is Required!")]
        public decimal ProductPrice { get; set; }
        [Column("productQuantity")]
        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "Prodcut Quantity is Required!")]
        public int ProductQuanity { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
