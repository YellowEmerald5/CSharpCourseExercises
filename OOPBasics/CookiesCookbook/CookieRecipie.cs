using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class CookieRecipie
    {
        public Ingredient[] Ingredients { get; init; }
        public CookieRecipie(Ingredient[] ingredients) {
            Ingredients = ingredients;
        }
    }
}
