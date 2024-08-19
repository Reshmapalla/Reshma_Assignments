using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeansAppAPI.Entities
{
    public class CartItem
    {
        [Key]

        public Guid CartId { get; set; }

        
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Column(TypeName = "decimal(18,2)")]
        public double Price { get; set; }

        // Derived property for total price, if you want to store it.
        [Column(TypeName = "decimal(18,2)")]
        public double TotalPrice { get; set; }

        // Navigation properties
       

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public Product? Product { get; set; }
    }
}

