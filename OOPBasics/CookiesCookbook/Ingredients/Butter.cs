using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Butter : Ingredient
    {
        public override int Id { get; init; } = 2;
        public override string Name { get; } = "Butter";
        public string Instruction { get; } = "Butter. Melt on low heat.";

        public Butter() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
