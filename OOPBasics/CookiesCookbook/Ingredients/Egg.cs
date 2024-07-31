using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Egg : Ingredient
    {
        public int Id { get; } = 6;
        public string Name { get; } = "Egg";
        public string Instruction { get; } = "Egg. Crack the shell and add contents to dry ingredients. Mix until homogenous.";

        public Egg() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
