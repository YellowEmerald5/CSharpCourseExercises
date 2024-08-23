using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
{
    public interface IAvailableIngredients
    {
        List<Ingredient> GetAvailableIngredients();
        Ingredient GetIngredientByID(int id);
    }
}
