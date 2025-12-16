namespace hospital_reservation_system.Data
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; } = new();

    }
}
