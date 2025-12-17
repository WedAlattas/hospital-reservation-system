using hospital_reservation_system.Data;
using hospital_reservation_system.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace hospital_reservation_system.Mapping
{
    // this class contains methods to map data models to view models and vice versa
    public static class ViewsMapping
    {


        public static List<Data.Appointment> MapToAppointments(AppointmentCreateViewModel model)
        {
            return model.SelectedTimeSlot.Select(slotId => new Data.Appointment
            {
                DoctorId = model.SelectedDoctorId,
                TimeSlotId = slotId
            }).ToList();
        }




        public static AppointmentIndexViewModel MapToViewModel(List<Doctor?> doctors, Data.User user)
        {

            return new AppointmentIndexViewModel
            {
                Doctors = doctors.MaptoDoctors(),
                user = user.MaptoUser()
            };

        }


        public static AppointmentCreateViewModel MapToViewModel(List<Doctor?> doctors, List<Data.TimeSlot> TimeSlots)
        {


            return new AppointmentCreateViewModel
            {
                Doctors = doctors.MaptoDoctors(),
                TimeSlots = TimeSlots.MaptoTimeSlots()
            };
        }


        public static AppointmentConfirmViewModel MapToView(Appointment? appointment)
        {
            return new AppointmentConfirmViewModel
            {
                appointment = appointment.MaptoAppointment()
            };


        }
        public static AppointmentsPreviousViewModel MapToView(List<Appointment> data)
        {
            return new AppointmentsPreviousViewModel
            {
                Appointments = data.MaptoAppointments()
            };


        }
    }
}
