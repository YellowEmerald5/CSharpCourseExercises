using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class ConsoleUI: IUserInteraction
    {

        private readonly IAvailableIngredients _availableIngredients;
        public ConsoleUI(IAvailableIngredients availableIngredients) {
            _availableIngredients = availableIngredients;
        }
        public List<Ingredient> InputForNewRecipie()
        {
            Console.WriteLine("Create a new cookie recipie! The available ingredients are:");
            foreach (var ingredient in _availableIngredients.GetAvailableIngredients())
            {
                Console.WriteLine(ingredient.ListIngredient());
            }
            string input = "";
            List<Ingredient> addedIngredients = new List<Ingredient>();
            bool isCompleted = false;
            do
            {
                Console.WriteLine("Write the Id of an ingredient or anything if the recipie is completed");
                input = Console.ReadLine();
                if (input != null && input.All(Char.IsDigit) && input.Length == 1)
                {
                    var result = Int32.Parse(input);
                    if (result >= 1 && result <= _availableIngredients.GetAvailableIngredients().Count)
                    {
                        addedIngredients.Add(_availableIngredients.GetIngredientByID(result));
                    }
                    else
                    {
                        Console.WriteLine("No ingredients added. The recipie will not be saved.");
                        isCompleted = true;
                    }
                }
                else
                {
                    if(addedIngredients.Count == 0)
                    {
                        Console.WriteLine("No ingredients added. The recipie will not be saved.");
                    }
                    isCompleted = true;
                }
            } while (!isCompleted);

            if (addedIngredients.Count > 0) {
                Console.WriteLine();
                Console.WriteLine("New Recipie added:");
            }
            return addedIngredients;
        }

        public void PrintNewRecipiePreparation(CookieRecipie newRecipie)
        {
            PrintIngredients(newRecipie);
        }

        public void PrintExistingRecipies(List<CookieRecipie> recipies)
        {
            Console.WriteLine("Existing recipies: ");
            Console.WriteLine();

            for (var i = 0; i < recipies.Count; i++)
            {
                Console.WriteLine("***** " + (i + 1) + " *****");
                PrintIngredients(recipies[i]);
                Console.WriteLine();
            }
        }

        private void PrintIngredients(CookieRecipie recipie)
        {
            foreach (var ingredient in recipie.Ingredients)
            {
                Console.WriteLine(ingredient.Preparation());
            }
        }
    }
}
