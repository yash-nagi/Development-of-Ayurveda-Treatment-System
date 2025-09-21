using System;

namespace Development_of_Ayurveda_Treatment_System.Models;

public class MedicineBookingViewModel
{
    public Medicine Medicine { get; set; }
    public MedicineBooking Booking { get; set; }
    public IEnumerable<Vendor> Vendors { get; set; }
}
