using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Data
{
    // Database context representing the application's database.
    public partial class DatabaseContext :DbContext
    {
        public DbSet<User> users => Set<User>();
        public DbSet<Doctor> doctors  => Set<Doctor>();
        public DbSet<Appointment> appointments => Set<Appointment>();
        public DbSet<TimeSlot> timeSlot => Set<TimeSlot>();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

      
        }

       

    }
}
