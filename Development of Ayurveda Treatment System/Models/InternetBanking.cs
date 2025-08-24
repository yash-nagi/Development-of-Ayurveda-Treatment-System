using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_InternetBanking")]
public class InternetBanking
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string UserId { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long AccountNo { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string BankName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string BankBranch { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string IFSCCode { get; set; }
    [Required]
    [Column(TypeName = "int")]
    public int IT_ID { get; set; }
}
