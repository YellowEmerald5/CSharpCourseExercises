using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
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

            var ingredientsList = _availableIngredients.GetAvailableIngredients()
                .Select(ingredient =>
                {
                    string ingredientListed = ingredient.ListIngredient();
                    return ingredientListed;
                });

            Console.WriteLine(string.Join(Environment.NewLine,ingredientsList));
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
            Console.WriteLine(PrintIngredients(newRecipie));
        }

        public void PrintExistingRecipies(List<CookieRecipie> recipies)
        {
            Console.WriteLine("Existing recipies: \n");

            var recipiesAsString = recipies.Select((recipie, index) => $"***** {index+1} *****\n{PrintIngredients(recipie)}\n");
            Console.WriteLine(string.Join(Environment.NewLine, recipiesAsString) + "\n");
        }

        private string PrintIngredients(CookieRecipie recipie)
        {
            var ingredientsAsString = recipie.Ingredients.Select(ingredient => ingredient.Preparation());
            return string.Join(Environment.NewLine, ingredientsAsString);
        }
    }
}
