using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;



namespace JeansAppAPI.Entities
{
    public class Product
    {
        // Primary key without regular expression validation
        [Key]
       
        public Guid ProductId { get; set; }

        // Required Product Name with a max length of 30 characters
        [Required(ErrorMessage = "Product Name is required.")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string ProductName { get; set; }

        // Required Price field
        [Required(ErrorMessage = "Product Price is required.")]
        public double Price { get; set; }

        // Foreign key for Category with a max length of 30 characters
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

       

        // Discount field
        public double Discount { get; set; }

        // Image URL field with a max length of 100 characters
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string ImageURL { get; set; }

        // Navigation property for the Category entity
       [JsonIgnore]
       public Category? Category { get; set; }
    }
}
