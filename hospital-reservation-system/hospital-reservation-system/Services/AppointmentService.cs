using hospital_reservation_system.Data;
using hospital_reservation_system.Mapping;
using hospital_reservation_system.Models;
using hospital_reservation_system.Repository;

namespace hospital_reservation_system.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository, IUserRepository userRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;
        }

        public async Task<AppointmentIndexViewModel> GetIndexAsync(int userId)
        {
            var Doctors = await _appointmentRepository.GetAvaliableAppointmentsAsync();
            var user = await _userRepository.GetUserAsync(userId);

            return new AppointmentIndexViewModel
            {
                Doctors = Doctors.MaptoDoctors(),
                user = user.MaptoUser()
            };

        }
        public async Task<AppointmentCreateViewModel> GetCreateAsync()
        {
            var Doctors = await _appointmentRepository.GetDoctorReservationsAsync();
            var TimeSlots = await _appointmentRepository.GetSlots();

            return  new AppointmentCreateViewModel
            {
                Doctors = Doctors.MaptoDoctors(),
                TimeSlots = TimeSlots.MaptoTimeSlots()
            };

        }

        public async Task<bool> CreateAppointmentAsync(AppointmentCreateViewModel model)
        {
            var data = AppointmentMapping.MapToAppointments(model);
            return  await _appointmentRepository.CreateAppointmentAsync(data);
        }

        public async Task<AppointmentsPreviousViewModel> GetAllPreviousAppointmentsAsync()
        {
            var result = await _appointmentRepository.GetPreviousAppointmentsAsync();
            return new AppointmentsPreviousViewModel
            {
                Appointments = result.MaptoAppointments()
            };
        }

        public async Task<AppointmentConfirmViewModel> GetConfirmAsync(int appointmentId)
        {
            Appointment? data = await _appointmentRepository.GetAppointmentById(appointmentId);
            if(data == null)
            {
                throw new Exception("Appointment not found");
            }
            else
            {
                return new AppointmentConfirmViewModel
                {
                    appointment = data.MaptoAppointment()
                };
            }
        }


        public async Task<bool> ConfirmAsync(int appointmentId, int userId)
        {
            return await _appointmentRepository.ReserveAppointment(appointmentId: appointmentId, userId: userId);
            
        }

    }
}
