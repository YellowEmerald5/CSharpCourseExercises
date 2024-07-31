using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Flour : Ingredient
    {
        public int Id { get; } = 1;
        public string Name { get; } = "Flour";
        public string Instruction { get; } = "Flour. Sieve into a bowl.";

        public Flour() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
