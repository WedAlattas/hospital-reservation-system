using hospital_reservation_system.Models;

namespace hospital_reservation_system.Services
{
    public interface IAppointmentService
    {
        Task<AppointmentIndexViewModel> GetIndexAsync(int userId);
        Task<AppointmentCreateViewModel> GetCreateAsync();
        Task<AppointmentsPreviousViewModel> GetAllPreviousAppointmentsAsync();
        Task<AppointmentConfirmViewModel> GetConfirmAsync(int appointmentId);
        Task<bool> CreateAppointmentAsync(AppointmentCreateViewModel model);
        Task<bool> ConfirmAsync(int appointmentId, int userId);

    }
}
