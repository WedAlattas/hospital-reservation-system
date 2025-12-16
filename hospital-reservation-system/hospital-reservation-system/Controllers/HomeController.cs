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
            // get all users from repository
            var Users = await _userRepository.GetAllUsersAsync();

            // map to view model
            HomeIndexViewModel model = new HomeIndexViewModel
            {
                Users = Users.MaptoUser()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int SelectedUserId)
        {
            // set the selected userId in cookies
            Response.Cookies.Delete("userId");
            Response.Cookies.Append("userId", SelectedUserId.ToString());
            return RedirectToAction("Index", "Appointment");
        }



        [HttpPost]
        public IActionResult Error()
        {
            return View(new ErrorViewModel());
        }
    }
}
