using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BO;
using TPPizzaENI.Models;

namespace TPPizzaENI.Controllers
{
    public class PizzaController : Controller
    {
        private static List<Pizza> pizzaList = new List<Pizza>()
        {
            new Pizza{ Id = 1, Nom = "Super Pizza", Pate = Pizza.GetPates().FirstOrDefault(),
                Ingredients = Pizza.GetIngredients().Take(2).ToList() },
            new Pizza{ Id = 2, Nom = "Trop Bonne Pizza", Pate = Pizza.GetPates().Skip(1).FirstOrDefault(),
                Ingredients = Pizza.GetIngredients().Skip(2).Take(2).ToList() },
            new Pizza{ Id = 3, Nom = "Pizza de Champion", Pate = Pizza.GetPates().Skip(2).FirstOrDefault(),
                Ingredients = Pizza.GetIngredients().Skip(4).Take(2).ToList() },
            new Pizza{ Id = 4, Nom = "Pizza Bof", Pate = Pizza.GetPates().Skip(3).FirstOrDefault(),
                Ingredients = Pizza.GetIngredients().Skip(6).Take(2).ToList() }
        };

        private Pizza GetPizza(int id)
        {
            return pizzaList.FirstOrDefault(p => p.Id == id);
        }

        private ActionResult DisplayPizza(int id)
        {
            Pizza pizza = GetPizza(id);
            if (pizza == null)
                return View("Error");

            DetailsPizza model = new DetailsPizza()
            {
                Pizza = pizza,
                ListeIngredients = string.Join(", ", pizza.Ingredients?.Select(i => i.Nom) ?? new string[] { }),
            };

            return View(model);
        }

        private static EditPizza GetEditPizza(Pizza pizza)
        {
            EditPizza model = new EditPizza()
            {
                Pizza = pizza,
                Pates = Pizza.GetPates().Select(p => new SelectListItem()
                {
                    Value = p.Id.ToString(),
                    Text = p.Nom,
                    Selected = pizza.Pate?.Id == p.Id,
                }),
                Ingredients = Pizza.GetIngredients().Select(i => new SelectListItem()
                {
                    Value = i.Id.ToString(),
                    Text = i.Nom,
                    Selected = true == pizza.Ingredients?.Any(ing => ing.Id == i.Id),
                    //Selected = (pizza.Ingredients?.Any(ing => ing.Id == i.Id)).GetValueOrDefault(false),
                    //Selected = pizza.Ingredients?.Any(ing => ing.Id == i.Id) ?? false,
                }),
                IngredientsSelectionnes = pizza.Ingredients?.Select(i => i.Id),
            };
            return model;
        }

        // GET: Pizza
        public ActionResult Index()
        {
            IEnumerable<ResumePizza> model = pizzaList.Select(p => new ResumePizza()
            {
                Id = p.Id,
                Nom = p.Nom
            });

            return View(model);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return DisplayPizza(id);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            Pizza pizza = new Pizza() { Pate = new Pate() };
            EditPizza model = GetEditPizza(pizza);
            return View(model);
        }

        // POST: Pizza/Create
        [HttpPost]
        //public ActionResult Create(EditPizza newPizza)
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Pizza pizza = new Pizza();
                pizza.Id = pizzaList.Max(p => p.Id) + 1;
                return MapPizza(pizza, collection, true);
            }
            catch
            {
                return View();
            }
        }

        private ActionResult MapPizza(Pizza pizza, FormCollection collection, bool addPizzaToList)
        {
            pizza.Nom = collection["Pizza.Nom"];

            if (!int.TryParse(collection["Pizza.Pate.Id"], out int idPate))
                return View("Error");

            Pate pate = Pizza.GetPates().FirstOrDefault(p => p.Id == idPate);
            if (pate == null)
                return View("Error");

            pizza.Pate = pate;

            if (collection["IngredientsSelectionnes"] != null)
            {
                IEnumerable<int> idIngredients = collection["IngredientsSelectionnes"].Split(',')
                    .Where(i => int.TryParse(i, out int result))
                    .Select(i => int.Parse(i));

                pizza.Ingredients = new List<Ingredient>(Pizza.GetIngredients().Where(ing => idIngredients.Contains(ing.Id)));
            }
            
            if(addPizzaToList)
            pizzaList.Add(pizza);

            return RedirectToAction("Index");
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            Pizza pizza = GetPizza(id);
            EditPizza model = GetEditPizza(pizza);

            return View(model);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = GetPizza(id);
                return MapPizza(pizza, collection, false);
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return DisplayPizza(id);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = pizzaList.FirstOrDefault(p => p.Id == id);
                if (pizzaList.Remove(pizza))
                    return RedirectToAction("Index");

                return View("Error");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
