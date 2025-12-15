using hospital_reservation_system.Data;

namespace hospital_reservation_system.Repository
{
    public interface IAppointmentRepository
    {
        Task<List<Doctor>> GetAllAvaliableAppointmentsAsync();

    }
    
}
