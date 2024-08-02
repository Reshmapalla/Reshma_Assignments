using System.ComponentModel.DataAnnotations;
namespace Assignment_1.Models
{
    public class Movie
    {
        [Required(ErrorMessage = "Plese enter Id")]
        public int MovieId {  get; set; }
        [Required(ErrorMessage = "Plese enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Plese enter Actor")]
        public string Actor { get; set; }
        [Required(ErrorMessage = "Plese enter Language")]

        public string Language { get; set; }
        [Required(ErrorMessage = "Plese enter Director")]

        public string Director { get; set; }
    }
}
