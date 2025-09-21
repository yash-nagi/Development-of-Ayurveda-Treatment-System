using System;

namespace Development_of_Ayurveda_Treatment_System.Models;

public class UserDashboardViewModel
{
    public int TotalAppointments { get; set; }
    public int CompletedAppointments { get; set; }
    public int PendingAppointments { get; set; }
    public int TotalPayments { get; set; }
    public long TotalAmountPaid { get; set; }
}
