using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace JeansAppAPI.Entities
{
    public class User
    {
        // Primary key for the User entity
        [Key]
        // The UserId field is stored as a varchar with a maximum length of 30 characters
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string UserId { get; set; }

        // Required field for the user's name with a maximum length of 30 characters
        [Required(ErrorMessage = "Name is Required")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Name { get; set; }

        // Required field for the user's email with email validation and a maximum length of 30 characters
        [Required(ErrorMessage = "Email is Required")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [EmailAddress(ErrorMessage = "Invalid EmailId")]
        public string Email { get; set; }

        // Required field for the user's password with a maximum length of 30 characters
        [Required(ErrorMessage = "Please Enter Password")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Password { get; set; }

        // Required field for the user's role with a maximum length of 30 characters
        [Required(ErrorMessage = "Role is Required")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Role { get; set; }

        // Required field for the user's mobile number with phone number validation
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        [Phone(ErrorMessage = "Invalid Mobile Number")]
        public string Mobile { get; set; }

    }
}
