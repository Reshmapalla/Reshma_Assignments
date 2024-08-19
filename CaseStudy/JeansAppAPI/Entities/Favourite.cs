using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JeansAppAPI.Entities
{
    public class Favourite
    {
        [Key]
       
       
       
        public Guid FavoriteId { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        
        public string UserId { get; set; }

        [Required(ErrorMessage = "ProductId is required.")]
       
        public Guid ProductId { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        [JsonIgnore] // Prevents serialization of this navigation property
        public User? User { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore] // Prevents serialization of this navigation property
        public Product? Product { get; set; }
    }
}
