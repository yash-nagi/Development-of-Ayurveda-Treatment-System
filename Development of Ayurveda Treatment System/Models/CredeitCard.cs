using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_CreditCard")]
public class CredeitCard
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string UserId { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long PaymentAmount { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime DateOfPayment { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long CreditCardID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string CardHolderName { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(20)")]
    public string CardExpDate { get; set; }
}
