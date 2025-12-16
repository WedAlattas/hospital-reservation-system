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
            var Doctors = await _appointmentRepository.GetAllAvaliableAppointmentsAsync();
            var user = await _userRepository.GetUserAsync(userId);

            return new AppointmentIndexViewModel
            {
                Doctors = Doctors.MaptoDoctors(),
                user = user.MaptoUser()
            };

        }
        public async Task<AppointmentCreateViewModel> GetCreateAsync()
        {
            var Doctors = await _appointmentRepository.GetAllDoctorReservationAsync();
            var TimeSlots = await _appointmentRepository.GetAllSlots();

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

        public async Task<AppointmentGetAllPreviousViewModel> GetAllPreviousAppointmentsAsync()
        {
            var result = await _appointmentRepository.GetAllPreviousAppointmentsAsync();
            return new AppointmentGetAllPreviousViewModel
            {
                Appointments = result.MaptoAppointments()
            };
        }
    }
}
