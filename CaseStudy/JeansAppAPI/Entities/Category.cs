using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JeansAppAPI.Entities
{
    public class Category
    {
        // Primary key for the Category entity
        [Key]
      
       
        public Guid CategoryId { get; set; }

        // Name of the category
        [Column(TypeName = "varchar")]
        [StringLength(100, ErrorMessage = "CategoryName cannot exceed 100 characters.")]
        [Required(ErrorMessage = "CategoryName is required.")]
        public string CategoryName { get; set; }

        // Description of the category
        [Column(TypeName = "varchar")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }
    }
}
