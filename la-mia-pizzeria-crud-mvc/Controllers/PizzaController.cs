using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente
using System.Diagnostics;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente
using la_mia_pizzeria_crud_mvc.Database;
using Microsoft.Identity.Client;
using la_mia_pizzeria_crud_mvc.CustomLoggers;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        private ICustomLogger _mylogger;
        private PizzaContext _myDatabase;
        public PizzaController(PizzaContext db, ICustomLogger logger)
        {
            _mylogger = logger;
            _myDatabase = db;
        }
        // AGGIUNGE UN PEZZO DI CODICE CHE SEMPLIFICA LA SINTASSI DI TUTTO IL CONTROLLER "_myDatabase"

        public IActionResult Index()
        {
            _mylogger.WriteLog("L'utente è arrivato sulla pagina Pizza > Index");

            List<Pizza> pizzas = _myDatabase.Pizzas.ToList<Pizza>();
            return View("Index", pizzas);

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
            List<Category> categories = _myDatabase.Categories.ToList();
            PizzaFormModel model = new PizzaFormModel { Pizza = new Pizza(), Categories = categories };
            return View("Create", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                List<Category> categories = _myDatabase.Categories.ToList();
                data.Categories = categories;
                return View("Create", data);
            }

            _myDatabase.Pizzas.Add(data.Pizza);
            _myDatabase.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {

            Pizza? pizzaToEdit = _myDatabase.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizzaToEdit == null)
            {
                return NotFound("La pizza non è stata trovata");
            }
            else
            {
                List<Category> categories = _myDatabase.Categories.ToList();

                PizzaFormModel model = new PizzaFormModel { Pizza = pizzaToEdit, Categories = categories };
                return View("Update", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                List<Category> categories = _myDatabase.Categories.ToList();
                data.Categories = categories;
                return View("Update", data);
            }
            data.Pizza.Id = id;
            Pizza? pizzaToUpdate = _myDatabase.Pizzas.Find(id);

            if (pizzaToUpdate != null)
            {
                EntityEntry<Pizza> entryEntity = _myDatabase.Entry(pizzaToUpdate);
                entryEntity.CurrentValues.SetValues(data.Pizza);

                _myDatabase.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound("Mi spiace, non sono state trovate Pizze da aggiornare");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {

            Pizza? pizzaToDelete = _myDatabase.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

            if (pizzaToDelete != null)
            {
                _myDatabase.Pizzas.Remove(pizzaToDelete);
                _myDatabase.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound("La Pizza da eliminare non è stata trovata");
            }

        }

    }
}
