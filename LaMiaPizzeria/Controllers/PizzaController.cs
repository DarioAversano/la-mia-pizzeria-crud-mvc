﻿using LaMiaPizzeria.DataBase;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

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
        // AZIONE PER LA CREAZIONE DI UNA PIZZA SIMILE A QUELLA DELLA MODIFICA 
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
        // azione COME CRAZIONE, SIMILE
        [HttpGet]
        public IActionResult modificaPizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? PizzaModifica = db.Pizza.Where(Pizza => Pizza.Id == id).FirstOrDefault();
                return View("modificaPizza", PizzaModifica);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult modificaPizza(int id, PizzaModel pizzaModificata)
        {
            if (!ModelState.IsValid)
            {
                return View("modificaPizza", pizzaModificata);
            }

            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaModificare = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaModificare != null)
                {
                    pizzaDaModificare.NomePizza = pizzaModificata.NomePizza;
                    pizzaDaModificare.Descrizione = pizzaModificata.Descrizione;
                    pizzaDaModificare.Immagine = pizzaModificata.Immagine;
                    pizzaDaModificare.Prezzo = pizzaModificata.Prezzo;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La pizza non è stata trovata");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreaNuovaPizza(PizzaModel nuovaPizza)
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




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult eliminaPizza(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaDaEliminare = db.Pizza.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDaEliminare != null)
                {
                    db.Remove(pizzaDaEliminare);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("La pizza non è stata trovata");
                }

            }
        }







    }

}


