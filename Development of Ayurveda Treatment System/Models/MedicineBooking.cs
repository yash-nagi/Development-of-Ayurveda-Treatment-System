using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_MedicineBooking")]
public class MedicineBooking
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int MedicineNo { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int BookingId { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime BookingDate { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string PaymentMode { get; set; }
    public string UserId { get; set; }
    public string VendorId { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int Quantity { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string MedicineId { get; set; }
}
