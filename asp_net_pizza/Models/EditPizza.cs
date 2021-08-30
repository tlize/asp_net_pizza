using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;

namespace TPPizzaENI.Models
{
    public class EditPizza
    {
        public Pizza Pizza { get; set; }
        public IEnumerable<SelectListItem> Pates { get; set; }
        public IEnumerable<SelectListItem> Ingredients { get; set; }
        public IEnumerable<int> IngredientsSelectionnes { get; set; }
    }
}