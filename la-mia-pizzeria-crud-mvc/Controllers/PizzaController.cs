using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente
using System.Diagnostics;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente
using la_mia_pizzeria_crud_mvc.Database;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizzas.ToList<Pizza>();
                return View("Index", pizzas);
            }
        }

        public IActionResult UserIndex()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizzas.ToList<Pizza>();
                return View("UserIndex", pizzas);
            }
        }

        public IActionResult Details(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Pizza? foundedPizza = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (foundedPizza == null)
                {
                    return NotFound($"La pizza con id:{id} non è stato trovato!");
                }
                else
                {
                    return View("Details", foundedPizza);
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", newPizza);
            }
            using(PizzaContext db = new PizzaContext)
            {
                db.Pizzas.Add(newPizza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}
