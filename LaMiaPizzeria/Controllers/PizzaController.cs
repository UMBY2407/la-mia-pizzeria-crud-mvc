using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

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
