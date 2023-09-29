using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_crud_mvc.Models;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente
using System.Diagnostics;  // Questa classe che richiamo, la sto artificialmente richiamando, non è stata scritta automaticamente

namespace la_mia_pizzeria_crud_mvc.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserIndex()
        {
            return View();
        }
    }
}
