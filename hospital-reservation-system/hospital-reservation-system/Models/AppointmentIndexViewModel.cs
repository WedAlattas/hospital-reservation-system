using hospital_reservation_system.Domain;

namespace hospital_reservation_system.Models
{
    public class AppointmentIndexViewModel
    {
        public List<Doctors> Doctors { get; set; }
        public User user { get; set; }
    }
}
