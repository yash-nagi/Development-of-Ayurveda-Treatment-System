using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Doctor")]
public class Doctor
{
    [Key]
    public string DoctorId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string DoctorName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ContactNo { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Department { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string AppointmentID { get; set; }
    [Required]
    [Column(TypeName = "date")]
    public DateTime AppointmentDate { get; set; }
    [Required]
    [Column(TypeName = "time")]
    public TimeSpan AppointmentTime { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ConsultationFees { get; set; }
}
