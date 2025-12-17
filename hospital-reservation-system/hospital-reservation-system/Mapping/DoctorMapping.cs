namespace hospital_reservation_system.Mapping
{

    // this class used to map Dctor the database entities with domain models 

    public static class DoctorMapping    
    {



        public static Domain.Doctors MaptoDoctor(this Data.Doctor doctor)
        {
            return new Domain.Doctors
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Appointments = doctor.Appointments.Select(a => a.MaptoAppointment()).ToList()
            };


        }

        public static List<Domain.Doctors> MaptoDoctors(this List<Data.Doctor> doctor)
        {
            return doctor.Select(u => u.MaptoDoctor()).ToList();
        }

    }
}
