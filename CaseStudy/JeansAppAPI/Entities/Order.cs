using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeansAppAPI.Entities
{
    public class Order
    {
        [Key]
       
        public Guid OrderId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "TotalPrice is Required")]
        public double TotalPrice { get; set; }

        [Required(ErrorMessage = "OrderStatus is Required")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "OrderDate is Required")]
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "DeliveryDate is Required")]
        [Column(TypeName = "Date")]
        public DateTime DeliveryDate { get; set; }

 
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Product? Product { get; set; }
    }
}

