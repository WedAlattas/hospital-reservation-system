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

        public async Task<bool> CreateAppointmentAsync(List<Appointment> appointments)
        {
       
            if (appointments == null || !appointments.Any())
            {
                return false;
            }

            try
            {
                foreach (var appointment in appointments)
                {
                    _databaseContext.Add(appointment);
                }

                return await _databaseContext.SaveChangesAsync()>0;
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding appointments");
                throw new Exception();
            }
        }

        public async Task<List<Doctor>> GetAllAvaliableAppointmentsAsync()
        {
            try
            {
                // get all avaliable appointments 
                return await _databaseContext.doctors.Include(d => d.Appointments.Where(s=> s.UserId==null)).ThenInclude(s=> s.Time).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching doctors with thier avaliable appointments");
                throw new Exception();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorReservationAsync()
        {
            try
            {
                // get all avaliable appointments 
                return await _databaseContext.doctors.Include(d => d.Appointments.Where(s => s.UserId != 0)).ThenInclude(s => s.Time).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching doctors with thier avaliable appointments");
                throw new Exception();
            }


        }

        public async Task<List<Appointment>> GetAllPreviousAppointmentsAsync()
        {


            try
            {
                // get all previous appointments 
                return await _databaseContext.appointments.Include(s=>s.Time).Include(s=> s.Doctor).Include(s=> s.User).Where(s=> s.User != null).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching previous appointments");
                throw new Exception();
            }



        }

        public async Task<List<TimeSlot>> GetAllSlots()
        {

            try
            {
                // get all static timeSlot 
                return await _databaseContext.timeSlot.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching the static timeSlots");
                throw new Exception();
            }
        }
    }
}
