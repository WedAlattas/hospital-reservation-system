using hospital_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly DatabaseContext _databaseContext;
        private readonly ILogger<AppointmentRepository> _logger;
        public AppointmentRepository(DatabaseContext databaseContext, ILogger<AppointmentRepository> logger) {
            _logger = logger;
            _databaseContext = databaseContext;
        }

        public async Task<List<Doctor>> GetAllAvaliableAppointmentsAsync()
        {
            try
            {
                // get all avaliable appointments 
                return await _databaseContext.doctors
                .Include(d => d.Appointments)
                .Where(d => d.Appointments.Any(a => a.UserId == null))
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching doctors with thier avaliable appointments");
                throw new Exception();
            }
        }
    }
}
