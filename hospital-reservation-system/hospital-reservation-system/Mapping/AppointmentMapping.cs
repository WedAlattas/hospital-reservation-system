namespace hospital_reservation_system.Mapping
{
    public static class AppointmentMapping
    {





        public static Domain.Appointments MaptoAppointment(this Data.Appointment appointments)
        {
            return new Domain.Appointments
            {
                Id = appointments.Id,
                DoctorId = appointments.DoctorId,
                TimeSlotId = appointments.TimeSlotId,
                UserId = appointments.UserId,
                SlotTime = appointments.Time.Time
            };


        }

        public static List<Domain.Appointments> MaptoAppointments(this List<Data.Appointment> appointments)
        {
            return appointments.Select(u => u.MaptoAppointment()).ToList();
        }




    }
}
