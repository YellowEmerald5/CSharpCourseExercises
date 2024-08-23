using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
{
    public class CookieRecipie
    {
        public List<Ingredient> Ingredients { get; set; }
        public CookieRecipie(List<Ingredient> ingredients) {
            Ingredients = ingredients;
        }
    }
}
