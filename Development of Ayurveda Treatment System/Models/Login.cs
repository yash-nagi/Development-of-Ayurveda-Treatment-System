using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models
{
    [Table("tbl_Login")]
    public class Login
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string Role { get; set; }
        [NotMapped]
        public bool RememberMe { get; set; }
    }
}
