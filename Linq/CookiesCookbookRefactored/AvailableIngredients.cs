using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
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
            var ingredientsWithId = availableIngredients.Where(ingredient => ingredient.Id == id);
            if (ingredientsWithId.Count() > 1) throw new InvalidOperationException($"Multiple ingredients with the id: {id} are present in the availableIngredients list");
            return ingredientsWithId.FirstOrDefault();
        }
    }
}
