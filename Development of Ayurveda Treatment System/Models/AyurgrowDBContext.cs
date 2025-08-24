using Microsoft.EntityFrameworkCore;

namespace Development_of_Ayurveda_Treatment_System.Models
{
    public class AyurgrowDBContext : DbContext
    {
        public AyurgrowDBContext(DbContextOptions<AyurgrowDBContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineBooking> MedicineBooking { get; set; }
        public DbSet<VendorBooking> VendorBookings { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CredeitCard> CredeitCards { get; set; }
        public DbSet<DebitCard> DebitCards { get; set; }
        public DbSet<InternetBanking> InternetBankings { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<EBooks> EBooks { get; set; }
        public DbSet<Employes> Employes { get; set; }
    }
}
