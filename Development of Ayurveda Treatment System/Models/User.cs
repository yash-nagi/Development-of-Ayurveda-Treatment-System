using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Web;

namespace Development_of_Ayurveda_Treatment_System.Models
{
    [Table("tbl_User")]
    public class Users
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string MiddleName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Gender { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string City { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Region { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int PostalCode { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Country { get; set; }
        [Required]
        [Column(TypeName = "bigint")]
        public long PhoneNo { get; set; }
        [Required]
        [Column(TypeName = "bigint")]
        public long MobileNo { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string DOB{ get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Nationality { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Religion { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ProfilePhoto { get; set; }
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] Imagepath { get; set; }
    }
}
