using Microsoft.AspNetCore.Mvc;
using MongoMvcDemo.Models;
using MongoMvcDemo.Services;

namespace MongoMvcDemo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;

        public EmployeeController(EmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index() => View(_service.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _service.Create(emp);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            var emp = _service.Get(id);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost]
        public IActionResult Edit(string id, Employee emp)
        {
            if (!ModelState.IsValid) return View(emp);
            _service.Update(id, emp);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(string id)
        {
            var emp = _service.Get(id);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}