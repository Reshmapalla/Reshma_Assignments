using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeansAppAPI.Entities
{
    public class Transaction
    {
        // Primary key for the Transaction entity
        [Key]
        public Guid TransactionId { get; set; }

        // Foreign key linking to the Order entity
        [Required(ErrorMessage = "OrderId is required.")]
        [ForeignKey("Order")] // Specifies the navigation property this foreign key references
        public Guid OrderId { get; set; }

        // Foreign key linking to the User entity
        [Required(ErrorMessage = "UserId is required.")]
        [Column(TypeName = "varchar")]
        [StringLength(10, ErrorMessage = "UserId can't exceed 10 characters.")]
        [ForeignKey("User")] // Specifies the navigation property this foreign key references
        public string UserId { get; set; }

        // Method used for the transaction (e.g., credit card, PayPal)
        [Required(ErrorMessage = "TransactionMethod is required.")]
        [StringLength(50, ErrorMessage = "Transaction method can't exceed 50 characters.")]
        public string TransactionMethod { get; set; }

        // Status of the transaction (e.g., completed, pending)
        [Required(ErrorMessage = "TransactionStatus is required.")]
        [StringLength(50, ErrorMessage = "Transaction status can't exceed 50 characters.")]
        public string TransactionStatus { get; set; }

        // Date and time when the transaction occurred
        [Required]
        public DateTime TransactionDate { get; set; }

        // Navigation property for the related Order entity
        [JsonIgnore] // Excludes this property from JSON serialization
        public Order? Order { get; set; }

        // Navigation property for the related User entity
        [JsonIgnore] // Excludes this property from JSON serialization
        public User? User { get; set; }
    }
}
