using hospital_reservation_system.Mapping;
using hospital_reservation_system.Models;
using hospital_reservation_system.Repository;
using Microsoft.AspNetCore.Mvc;

namespace hospital_reservation_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;
        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var Users = await _userRepository.GetAllUsersAsync();


            HomeIndexViewModel model = new HomeIndexViewModel
            {
                Users = Users.MaptoUser()
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }
    }
}
