using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_VendorBooking")]
public class VendorBooking
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int MedicineNo { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string BookingID { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime BookingDate { get; set; }
    public string VendorD { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string PaymentMode { get; set; }
}
