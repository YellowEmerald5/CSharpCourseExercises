using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored.Ingredients
{
    public class Milk : Ingredient
    {
        public override int Id { get; init; } = 4;
        public override string Name { get; } = "Milk";
        public override string Instructions { get; } = "Milk. Add to dry ingredients and mix.";

        public Milk() { }

        public override string Preparation()
        {
            return Instructions;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
