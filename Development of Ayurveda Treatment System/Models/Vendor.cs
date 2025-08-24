using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Vendor")]
public class Vendor
{
    [Key]
    public string VendorId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string VendorName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Address { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ContactNo { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long RegistrationNo { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long FaxNo { get; set; }
}
