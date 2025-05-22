using Microsoft.AspNetCore.Mvc;
using OdontoVision.Application.ViewModels;

namespace OdontoVision.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            var pacientes = new List<PacienteViewModel>
            {
                new PacienteViewModel { Id = 1, Nome = "João Silva" },
                new PacienteViewModel { Id = 2, Nome = "Maria Oliveira" }
            };
            return View(pacientes);
        }

        public IActionResult Details(int id)
        {
            var paciente = new PacienteViewModel { Id = id, Nome = "João Silva" };
            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PacienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var paciente = new PacienteViewModel { Id = id, Nome = "João Silva" };
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(PacienteViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var paciente = new PacienteViewModel { Id = id, Nome = "João Silva" };
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
