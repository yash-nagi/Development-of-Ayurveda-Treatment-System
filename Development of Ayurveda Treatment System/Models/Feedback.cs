using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;


[Table("tbl_Feedback")]
public class Feedback
{
    [Key]
    public string FeedbackId { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    [Column(TypeName = "nvarchar(50)")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Message is required")]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Message { get; set; }
    [Required]
    [Column(TypeName = "datetime")]
    public DateTime SubmittedOn { get; set; } = DateTime.Now;
}
