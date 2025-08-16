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
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Role { get; set; }
    }
}
