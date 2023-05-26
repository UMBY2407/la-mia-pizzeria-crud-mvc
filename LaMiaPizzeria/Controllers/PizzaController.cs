using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LaMiaPizzeria.Models.ModelForViews;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<Pizza> ourTecArticles = db.Pizzas.ToList();
                return View(ourTecArticles);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                List<PizzaCategory> pizzaCategories = db.PizzaCategories.ToList();

                PizzaListCategory modelForView = new PizzaListCategory();
                modelForView.Pizzas = new Pizza();
                modelForView.PizzaCategories = pizzaCategories;

                return View(modelForView);
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaToModify != null)
                {
                    return View("Update", pizzaToModify);
                }
                else
                {
                    return NotFound("Pizza da modificare inesistente");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaListCategory data)
        {
            if (!ModelState.IsValid)
            {
                using(PizzeriaContext db = new PizzeriaContext())
                {
                    List<PizzaCategory> pizzaCategories = db.PizzaCategories.ToList();
                    data.PizzaCategories = pizzaCategories;
                    return View("Create", data);
                }
            }

            using (PizzeriaContext db = new PizzeriaContext())
            {
                db.Pizzas.Add(data.Pizzas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using(PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizzaToDelete = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                if(pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                } else
                {
                    return NotFound("Non ho trovato la pizza da eliminare");
                }
            }
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Update(int id, PizzaListCategory data)
        {
            if (!ModelState.IsValid)
            {
                using (PizzeriaContext db = new PizzeriaContext())
                {
                    List<PizzaCategory> pizzaCategories = db.PizzaCategories.ToList();
                    data.PizzaCategories = pizzaCategories;

                    return View("Update", data);
                }
            }
            else
            {
                using (PizzeriaContext db = new PizzeriaContext())
                {
                    Pizza? pizzaToModify = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                    if (pizzaToModify != null)
                    {
                        pizzaToModify.Name = data.Pizzas.Name;
                        pizzaToModify.Description = data.Pizzas.Description;
                        pizzaToModify.Image = data.Pizzas.Image;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound("L'articolo da modificare non esiste!");
                    }
                }
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzeriaContext db = new PizzeriaContext())
            {
                Pizza? pizzaDetails = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaDetails != null)
                {
                    return View("Details", pizzaDetails);
                }
                else
                {
                    return NotFound($"La pizza con id {id} non è stato trovato!");
                }
            }
        }
    }
}