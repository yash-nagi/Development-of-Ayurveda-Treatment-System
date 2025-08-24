using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Development_of_Ayurveda_Treatment_System.Models;

[Table("tbl_Payment")]
public class Payment
{
    [Key]
    public string ID { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string UserId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string PaymentMode { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long Amount { get; set; }
    [Column(TypeName = "bigint")]
    public long CreditCardID { get; set; }
    [Column(TypeName = "bigint")]
    public long DebitCardID { get; set; }
    [Required]
    [Column(TypeName = "DATETIME")]
    public DateTime PaymentDate { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string InternetBanking { get; set; }
    [Required]
    [Column(TypeName = "bigint")]
    public long ReceiptNo { get; set; }
}
