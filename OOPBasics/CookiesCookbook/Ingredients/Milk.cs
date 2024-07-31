using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Milk : Ingredient
    {
        public int Id { get; } = 4;
        public string Name { get; } = "Milk";
        public string Instruction { get; } = "Milk. Add to dry ingredients and mix.";

        public Milk() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
