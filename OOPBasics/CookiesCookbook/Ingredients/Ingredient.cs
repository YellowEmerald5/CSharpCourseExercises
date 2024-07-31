using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Ingredient
    {
        public virtual string Preparation() => "Ingredients must be prepared as instructed prior to baking";
        public virtual string ListIngredient() => string.Empty;
    }
}
