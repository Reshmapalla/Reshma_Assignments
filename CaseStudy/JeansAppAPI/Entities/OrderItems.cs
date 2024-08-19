using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeansAppAPI.Entities
{
    public class OrderItems
    {
        // Primary key for the OrderItems table
        [Key]
       
        public Guid OrderItemId { get; set; }

        // Foreign key referencing the Order table
        [Required(ErrorMessage = "OrderId is required.")]
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        // Foreign key referencing the Product table
        [Required(ErrorMessage = "ProductId is required.")]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        // Quantity of the product in the order item
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        // Price per unit of the product
        [Required(ErrorMessage = "UnitPrice is required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        // Total price for the order item (to be calculated on the frontend)
        [Required(ErrorMessage = "TotalPrice is required.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        // Navigation properties for related entities
        [JsonIgnore]
        public Order? Order { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}
