using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductSystemManagement.Controllers
{
    public class DashboardContoller : Controller
    {

        private readonly ILogger<DashboardContoller> _logger;

        public DashboardContoller(ILogger<DashboardContoller> logger)
        {
            _logger = logger;
        }

        // GET: DashboardContoller
        public IActionResult Index()
        {
            return View();
        }

        // GET: DashboardContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DashboardContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DashboardContoller/Create
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

        // GET: DashboardContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DashboardContoller/Edit/5
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

        // GET: DashboardContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DashboardContoller/Delete/5
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
