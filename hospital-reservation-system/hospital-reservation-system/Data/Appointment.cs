namespace hospital_reservation_system.Data
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot Time { get; set; }

        public int? UserId { get; set; }  
        public User? User { get; set; }

    }
}
