using asp_net_pizza.Models;
using System.Web.Mvc;

namespace asp_net_pizza.Controllers
{
    public class PizzaController : Controller
    {

        // GET: Pizza
        public ActionResult Index()
        {
            return View(Pizza.GetMenuExpress());
        }


        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View(Pizza.GetUnePizza(id));
        }



        // GET: Pizza/Create
        public ActionResult Create()
        {
            TempData["ingredients"] = Pizza.GetIngredients();
            TempData["pates"] = Pizza.GetPates();
            return View();
        }

        // POST: Pizza/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Pizza pizza)
        {
            try
            {
                TempData["msg"] = "nouvelle pizza : " + pizza.Nom;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            TempData["ingredients"] = Pizza.GetIngredients();
            TempData["pates"] = Pizza.GetPates();
            return View(Pizza.GetUnePizza(id));
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pizza pizza)
        {
            try
            {
                TempData["msg"] = "nouveau nom : " + pizza.Nom;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Pizza.GetUnePizza(id));
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pizza pizza)
        {
            try
            {
                TempData["msg"] = "pizza supprimée : " + pizza.Id;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



    }
}
