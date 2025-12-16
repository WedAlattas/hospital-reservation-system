using hospital_reservation_system.Data;
using hospital_reservation_system.Domain;

namespace hospital_reservation_system.Mapping
{

    // this class used to map the database entities with ViewModel 
    public static class UserMapping
    {

        public static Domain.User MaptoUser(this Data.User user)
        {
            return new Domain.User
            {
                Id = user.Id,
                UserName = user.UserName,
                IsAdmin = user.IsAdmin
            };


        }

        public static List<Domain.User> MaptoUser(this List<Data.User> users)
        {
            return users.Select(u => u.MaptoUser()).ToList();

        }




    }
}
