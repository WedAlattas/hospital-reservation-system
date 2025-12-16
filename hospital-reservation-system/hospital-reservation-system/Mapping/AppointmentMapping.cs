using hospital_reservation_system.Models;

namespace hospital_reservation_system.Mapping
{
    public static class AppointmentMapping
    {

        public static List<Data.Appointment> MapToAppointments(
     AppointmentCreateViewModel model)
        {
            return model.SelectedTimeSlot.Select(slotId => new Data.Appointment
            {
                DoctorId = model.SelectedDoctorId,
                TimeSlotId = slotId
            }).ToList();
        }



        public static Domain.Appointments MaptoAppointment(this Data.Appointment appointments)
        {
            return new Domain.Appointments
            {
                Id = appointments.Id,
                DoctorId = appointments.DoctorId,
                TimeSlotId = appointments.TimeSlotId,
                UserId = appointments.UserId,
                SlotTime = appointments.Time.Time, 
                UserName = appointments.User != null ? appointments.User.UserName : ""
               , DoctorName = appointments.Doctor != null ? appointments.Doctor.Name : ""
            };


        }

        public static List<Domain.Appointments> MaptoAppointments(this List<Data.Appointment> appointments)
        {
            return appointments.Select(u => u.MaptoAppointment()).ToList();
        }



        public static Domain.TimeSlot MaptoTimeSlot(this Data.TimeSlot slot)
        {
            return new Domain.TimeSlot
            {
                Id = slot.Id,
                Time = slot.Time
            };
        }

        public static List<Domain.TimeSlot> MaptoTimeSlots(this List<Data.TimeSlot> slots)
        {
            return slots.Select(u => u.MaptoTimeSlot()).ToList();
        }



    }
}
