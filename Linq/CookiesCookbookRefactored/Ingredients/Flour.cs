using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored.Ingredients
{
    public class Flour : Ingredient
    {
        public override int Id { get; init; } = 1;
        public override string Name { get; } = "Flour";
        public override string Instructions { get; } = "Flour. Sieve into a bowl.";

        public Flour() { }

        public override string Preparation()
        {
            return Instructions;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
