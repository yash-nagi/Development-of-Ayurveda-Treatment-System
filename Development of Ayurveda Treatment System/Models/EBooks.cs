using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_EBooks")]
public class EBooks
{
    [Key]
    public string BookId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string BookName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string AuthorName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string EditionNo { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime DateOfPublish { get; set; }
}
