using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public static class AvailableIngredients
    {
        private static List<Ingredient> availableIngredients = new List<Ingredient>
        {
            new Flour(),
            new Butter(),
            new Sugar(),
            new Milk(),
            new Chocolate(),
            new Egg()
        };

        public static List<Ingredient> GetAvailableIngredients() => availableIngredients;
    }
}
