using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class AvailableIngredients : IAvailableIngredients
    {
        private List<Ingredient> availableIngredients = new List<Ingredient>
        {
            new Flour(),
            new Butter(),
            new Sugar(),
            new Milk(),
            new Chocolate(),
            new Egg()
        };

        public List<Ingredient> GetAvailableIngredients() => availableIngredients;
        public Ingredient GetIngredientByID(int id){
            Ingredient ingredient = null;
            for (int i = 0; i < availableIngredients.Count; i++) {
                if (availableIngredients[i].Id == id)
                {
                    ingredient = availableIngredients[i];
                }
            }
            return ingredient;
        }
    }
}
