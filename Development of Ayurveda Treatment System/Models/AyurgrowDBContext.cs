using Microsoft.EntityFrameworkCore;

namespace Development_of_Ayurveda_Treatment_System.Models
{
    public class AyurgrowDBContext : DbContext
    {
        public AyurgrowDBContext(DbContextOptions<AyurgrowDBContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
