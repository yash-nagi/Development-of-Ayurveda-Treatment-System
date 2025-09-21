using System;

namespace Development_of_Ayurveda_Treatment_System.Models;

public class PaymentViewModel
{
    public string UserId { get; set; }
    public string VendorId { get; set; }
    public string MedicineId { get; set; }
    public long Amount { get; set; }
    public int Quantity { get; set; }
    public int MedicineNo { get; set; }
    public string PaymentMode { get; set; }
    // Models for different payment modes
    public CredeitCard CreditCard { get; set; }
    public DebitCard DebitCard { get; set; }
    public InternetBanking InternetBanking { get; set; }
}
