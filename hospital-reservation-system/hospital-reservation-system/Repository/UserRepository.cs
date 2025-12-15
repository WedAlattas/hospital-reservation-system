using hospital_reservation_system.Data;
using Microsoft.EntityFrameworkCore;

namespace hospital_reservation_system.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(DatabaseContext context, ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async  Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                // get all users 
                return await _context.users.OrderBy(u => u.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError( ex, "Error while fetching all the users");
               throw new Exception();

            }
        }

        public async Task<User?> GetUserAsync(int Id)
        {
            try
            {
                // get user by id  
                return await _context.users.FirstOrDefaultAsync(u => u.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching user by id");
                throw new Exception();

            }
        }
    }
}
