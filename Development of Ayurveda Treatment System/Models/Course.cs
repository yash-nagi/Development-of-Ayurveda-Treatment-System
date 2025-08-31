using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Course")]
public class Course
{
    [Key]
    public string CourseId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string CourseName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string CourseDuration { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long CourseFeeStruc { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(max)")]
    public string Benefits { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string InstituteName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(200)")]
    public string InstituteAddress { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public long InstituteContactNo { get; set; }
}
