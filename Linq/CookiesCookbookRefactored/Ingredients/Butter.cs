using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored.Ingredients
{
    public class Butter : Ingredient
    {
        public override int Id { get; init; } = 2;
        public override string Name { get; } = "Butter";
        public override string Instructions { get; } = "Butter. Melt on low heat.";

        public Butter() { }

        public override string Preparation()
        {
            return Instructions;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
