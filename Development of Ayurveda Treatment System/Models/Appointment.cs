using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Appointment")]
public class Appointment
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string DoctorId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string UserId { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime AppointmentDate { get; set; }
    [Required]
    [Column(TypeName = "time")]
    public TimeSpan AppointmentTime { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ConsultationFee { get; set; }
}
