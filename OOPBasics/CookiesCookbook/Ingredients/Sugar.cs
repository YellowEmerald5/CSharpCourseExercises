using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Sugar : Ingredient
    {
        public override int Id { get; init; } = 3;
        public override string Name { get; } = "Sugar";
        public string Instruction { get; } = "Sugar. Add to dry ingredients.";

        public Sugar() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
