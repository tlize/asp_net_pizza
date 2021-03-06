using asp_net_pizza.Models;
using BO;
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

        public ActionResult Create(FormCollection collection)
        {
            try
            {
                TempData["msg"] = "nouvelle pizza : " + collection["Nom"] + ", pâte : " + collection["Pate"];
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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                TempData["msg"] = "nouveau nom : " + collection["Nom"] + ", pâte : " + collection["pate"];
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
        public ActionResult Delete(Pizza pizza, FormCollection collection)
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
