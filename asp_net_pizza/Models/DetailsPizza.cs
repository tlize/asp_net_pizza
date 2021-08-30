using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BO;

namespace TPPizzaENI.Models
{
    public class DetailsPizza
    {
        public Pizza Pizza { get; set; }

        [Display(Name = "Liste des ingrédients :")]
        public string ListeIngredients { get; set; }
    }
}