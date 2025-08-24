using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Employes")]
public class Employes
{
    [Key]
    public string EmployeeId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Emp_First_Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Emp_Middle_Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Emp_Last_Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Sex { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string Address { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string State { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ContactNo { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime Emp_DOB { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime DateOfJoining { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long Salary { get; set; }
}
