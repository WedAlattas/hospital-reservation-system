
namespace hospital_reservation_system.Domain
{
    public class Appointments
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public int TimeSlotId { get; set; }
        public string SlotTime { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }

    }
}
