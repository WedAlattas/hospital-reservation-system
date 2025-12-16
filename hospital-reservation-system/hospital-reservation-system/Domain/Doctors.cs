using hospital_reservation_system;

namespace hospital_reservation_system.Domain
{
    public class Doctors
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Appointments> Appointments { get; set; } = new();
    }
}
