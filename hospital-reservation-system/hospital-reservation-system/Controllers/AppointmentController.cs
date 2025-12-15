using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospital_reservation_system.Controllers
{
    public class AppointmentController : Controller
    {
        // GET: appointmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: appointmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: appointmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: appointmentController/Create
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

        // GET: appointmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: appointmentController/Edit/5
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

        // GET: appointmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: appointmentController/Delete/5
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
