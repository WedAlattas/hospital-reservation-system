using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; } = false;

        public List<Appointment> Appointments { get; set; } = new();

    }
}
