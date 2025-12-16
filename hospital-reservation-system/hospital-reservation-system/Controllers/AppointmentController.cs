using hospital_reservation_system.Mapping;
using hospital_reservation_system.Models;
using hospital_reservation_system.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace hospital_reservation_system.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentController(IUserRepository userRepository, IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
            _userRepository = userRepository;   

        }

        [HttpGet]
        public async Task<ActionResult> Index(int SelectedUserId)
        {


            var Doctors = await _appointmentRepository.GetAllAvaliableAppointmentsAsync();
            var user =await _userRepository.GetUserAsync(SelectedUserId);

            AppointmentIndexViewModel model = new AppointmentIndexViewModel
            {
                Doctors = Doctors.MaptoDoctors(), 
                user = user.MaptoUser()
            };

            return View(model);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

   
        public ActionResult Edit(int id)
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
