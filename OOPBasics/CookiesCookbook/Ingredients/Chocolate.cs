﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.Ingredients
{
    public class Chocolate : Ingredient
    {
        public override int Id { get; init; } = 5;
        public override string Name { get; } = "Chocolate";
        public string Instruction { get; } = "Chocolate. Add to dry ingredients and mix.";

        public Chocolate() { }

        public override string Preparation()
        {
            return Instruction;
        }
        public override string ListIngredient() => Id + ". " + Name;

    }
}
