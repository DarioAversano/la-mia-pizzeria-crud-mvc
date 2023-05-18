using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaMiaPizzeria.Controllers;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<PizzaModel> pizze = db.Pizza.ToList();
                return View("Index", pizze);
            }
            
        }

        [HttpGet]
        public IActionResult Creazione()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Creazione(PizzaModel nuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Creazione", nuovaPizza);
            }

            using (PizzaContext db = new PizzaContext())
            {
                db.Pizza.Add(nuovaPizza);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

        }



    }
}
