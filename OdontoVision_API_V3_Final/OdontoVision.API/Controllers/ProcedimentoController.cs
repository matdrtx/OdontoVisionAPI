using Microsoft.AspNetCore.Mvc;
using OdontoVision.Application.ViewModels;

namespace OdontoVision.Controllers
{
    public class ProcedimentoController : Controller
    {
        public IActionResult Index()
        {
            var procedimentos = new List<ProcedimentoViewModel>
            {
                new ProcedimentoViewModel { Id = 1, Nome = "Limpeza", Preco = 100.00m },
                new ProcedimentoViewModel { Id = 2, Nome = "Clareamento", Preco = 250.00m }
            };
            return View(procedimentos);
        }

        public IActionResult Details(int id)
        {
            var procedimento = new ProcedimentoViewModel { Id = id, Nome = "Limpeza", Preco = 100.00m };
            return View(procedimento);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProcedimentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var procedimento = new ProcedimentoViewModel { Id = id, Nome = "Limpeza", Preco = 100.00m };
            return View(procedimento);
        }

        [HttpPost]
        public IActionResult Edit(ProcedimentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var procedimento = new ProcedimentoViewModel { Id = id, Nome = "Limpeza", Preco = 100.00m };
            return View(procedimento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
