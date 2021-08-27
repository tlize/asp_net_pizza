using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BO
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        [DisplayName("Pâte")]
        public Pate Pate { get; set; }
        [DisplayName("Ingrédients")]
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


        

        public static List<Pizza> GetMenuExpress()
        {
            List<Ingredient> listeIngredients = GetIngredients();
            List<Pate> listePates = GetPates();

            return new List<Pizza>
            {
                new Pizza{ Id = 1, Nom = "Super Pizza", Pate = listePates.FirstOrDefault(),
                    Ingredients = listeIngredients.Take(2).ToList() },

                new Pizza{ Id = 2, Nom = "Trop Bonne Pizza", Pate = listePates.Skip(1).FirstOrDefault(),
                    Ingredients = listeIngredients.Skip(2).Take(2).ToList() },

                new Pizza{ Id = 3, Nom = "Pizza de Champion", Pate = listePates.Skip(2).FirstOrDefault(),
                    Ingredients = listeIngredients.Skip(4).Take(2).ToList() },

                new Pizza{ Id = 4, Nom = "Pizza Bof", Pate = listePates.Skip(3).FirstOrDefault(),
                    Ingredients = listeIngredients.Skip(6).Take(2).ToList() }
            };

        }


        public static Pizza GetUnePizza(int id)
        {
            return GetMenuExpress().FirstOrDefault(m => m.Id == id);
        }


        public static List<Pate> GetPates()
        {
            return new List<Pate>
            {
            new Pate{ Id=1,Nom="Pate fine, base crême"},
            new Pate{ Id=2,Nom="Pate fine, base tomate"},
            new Pate{ Id=3,Nom="Pate épaisse, base crême"},
            new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };
        }

        public static List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>
            {
            new Ingredient{Id=1,Nom="Mozzarella"},
            new Ingredient{Id=2,Nom="Jambon"},
            new Ingredient{Id=3,Nom="Tomate"},
            new Ingredient{Id=4,Nom="Oignon"},
            new Ingredient{Id=5,Nom="Cheddar"},
            new Ingredient{Id=6,Nom="Saumon"},
            new Ingredient{Id=7,Nom="Champignon"},
            new Ingredient{Id=8,Nom="Poulet"}
            };
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}