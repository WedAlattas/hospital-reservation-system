using hospital_reservation_system.Data;

namespace hospital_reservation_system.Repository
{
    public interface IAppointmentRepository
    {
        Task<List<Doctor>> GetAvaliableAppointmentsAsync();
        Task<List<Appointment>> GetPreviousAppointmentsAsync();
        Task<List<TimeSlot>> GetSlots();
        Task<List<Doctor>> GetDoctorReservationsAsync();
        Task<bool> CreateAppointmentAsync(List<Appointment> appointments);
        Task<Appointment?> GetAppointmentById(int Id);
        Task<bool> ReserveAppointment(int appointmentId, int userId);
    }
    
}
