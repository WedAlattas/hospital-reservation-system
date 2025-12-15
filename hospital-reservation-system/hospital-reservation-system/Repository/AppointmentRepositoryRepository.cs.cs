using hospital_reservation_system.Data;

namespace hospital_reservation_system.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly DatabaseContext _databaseContext;
        public AppointmentRepository(DatabaseContext databaseContext) {

            _databaseContext = databaseContext;
        }

        

    }
}
