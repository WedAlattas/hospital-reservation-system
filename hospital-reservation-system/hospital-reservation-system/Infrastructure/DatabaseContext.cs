using hospital_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Data
{
    // Extending the DatabaseContext to seed initial data
    public partial class DatabaseContext 
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed initial data for Doctors, and Appointments

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Doctor>().HasData(
               new Doctor { Id = 1, Name = "Dr. Ahmed"},
               new Doctor { Id = 2, Name = "Dr. Sara"},
               new Doctor { Id = 3, Name = "Dr. Wed" },
               new Doctor { Id = 4, Name = "Dr. Mohammed" }
           );

            modelBuilder.Entity<TimeSlot>().HasData(
              new TimeSlot { Id = 1, Time = "3:30" },
              new TimeSlot { Id = 2, Time = "14:45" },
              new TimeSlot { Id = 3, Time = "10:30" },
              new TimeSlot { Id = 4, Time = "13:00" },
              new TimeSlot { Id = 5, Time = "18:00" },
              new TimeSlot { Id = 6, Time = "20:15" },
              new TimeSlot { Id = 7, Time = "21:00" }

          );


            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, UserName = "patient1" },
            new User { Id = 2, UserName = "patient2" },
            new User { Id = 3, UserName = "patient3" },
            new User { Id = 4, UserName = "patient4" },
            new User { Id = 5, UserName = "admin" , IsAdmin=true}
        );
        }
    }
}
