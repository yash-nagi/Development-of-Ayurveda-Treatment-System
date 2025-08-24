using System;

namespace Development_of_Ayurveda_Treatment_System.Models;

public class Admin
{
    public string FullName { get; set; }
    // Dashboard Statistics
    public int TotalMedicines { get; set; }
    public int TotalVendors { get; set; }
    public int TotalCourses { get; set; }
    public int TotalDoctors { get; set; }
    public int TotalEBooks { get; set; }
    public int TotalBillings { get; set; }
    public int TotalUsers { get; set; }
}
