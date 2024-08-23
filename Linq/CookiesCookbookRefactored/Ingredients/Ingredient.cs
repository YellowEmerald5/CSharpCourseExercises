using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored.Ingredients
{
    public class Ingredient
    {
        public virtual int Id { get; init; }
        public virtual string Name { get; } = "";
        public virtual string Instructions { get; } = "";

        public Ingredient() { }
        public virtual string Preparation() => "Ingredients must be prepared as instructed prior to baking";
        public virtual string ListIngredient() => string.Empty;
    }
}
