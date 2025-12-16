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

        public async Task<Appointment?> GetAppointmentById(int Id)
        {
            try
            {
                // get by Id appointment
                return await _databaseContext.appointments.Include(s => s.Time).Include(s => s.Doctor).Where(s => s.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching get an appointment id: {Id}");
                throw new Exception();
            }
        }

        public async Task<List<Doctor>> GetAvaliableAppointmentsAsync()
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

        public async Task<List<Doctor>> GetDoctorReservationsAsync()
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

        public async Task<List<Appointment>> GetPreviousAppointmentsAsync()
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

        public async Task<List<TimeSlot>> GetSlots()
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

        public async Task<bool> ReserveAppointment(int appointmentId, int userId)
        {
            if(appointmentId <=0 || userId <=0)
            {
                return false;
            }

            try
            {
                var appointment = await GetAppointmentById(appointmentId);
                if(appointment == null)
                {
                    return false;
                }
                appointment.UserId = userId;
                _databaseContext.Update(appointment);
                return await _databaseContext.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while updating appointments (Reserve an appointment) userId: {userId} appointmentId: {appointmentId}");
                throw new Exception();
            }
        }
    }
}
