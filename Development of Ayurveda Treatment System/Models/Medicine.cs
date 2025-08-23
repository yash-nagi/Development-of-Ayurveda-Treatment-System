using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Medicine")]
public class Medicine
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int MedicineNo { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string MedicineName { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int MedicineBatchNo { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string ManufacturerName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string ManufacturerAddress { get; set; }
    public string VendorID { get; set; }
    public string UserID { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime DateOfManufactured { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime DateOfExpire { get; set; }
}
