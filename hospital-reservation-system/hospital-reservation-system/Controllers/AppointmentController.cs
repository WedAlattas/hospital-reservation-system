using hospital_reservation_system.Mapping;
using hospital_reservation_system.Models;
using hospital_reservation_system.Repository;
using hospital_reservation_system.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Principal;
using System.Threading.Tasks;

namespace hospital_reservation_system.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            // getting the userId from cookies
            int userId = 0;
            if (Request.Cookies.TryGetValue("userId", out var value))
            {
                int.TryParse(value, out userId);
            }
            // getting the model data from service
            AppointmentIndexViewModel model = await _appointmentService.GetIndexAsync(userId);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            // getting the model data from service
            AppointmentCreateViewModel model = await _appointmentService.GetCreateAsync();
            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> Create(AppointmentCreateViewModel model)
        {
            try
            {
                // validate the model (Selected doctor and timeSlot)
                if (!ModelState.IsValid)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Please complete all required fields before submitting.");
                    model = await _appointmentService.GetCreateAsync();
                    return View(model);
                }
                else
                {
                    // save the appointment
                    var saved = await _appointmentService.CreateAppointmentAsync(model);
                    if (!saved)
                    {
                        // in case there is an error while saving the appointment
                        ModelState.AddModelError("", "Failed to create appointment.");
                        model = await _appointmentService.GetCreateAsync();
                        return View(model);
                    }
                    else
                    {
                        // if everything is fine redirect to appointments list page
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                // in case there is an exception while saving the appointment
                model = await _appointmentService.GetCreateAsync();
                ModelState.AddModelError("", "Failed to create appointment.");
                return View(model);

            }
        }
    }
    }