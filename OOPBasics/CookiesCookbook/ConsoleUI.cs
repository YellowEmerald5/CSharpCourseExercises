using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public static class ConsoleUI
    {
        public static List<int> RecipieInput()
        {
            var availableIngredients = AvailableIngredients.GetAvailableIngredients();
            Console.WriteLine("Create a new cookie recipie! The available ingredients are:");
            foreach (var ingredient in availableIngredients)
            {
                Console.WriteLine(ingredient.ListIngredient());
            }
            string input = "";
            List<int> addedIngredients = new List<int>();
            bool isCompleted = false;
            do
            {
                Console.WriteLine("Write the Id of an ingredient or anything if the recipie is completed");
                input = Console.ReadLine();
                if (input != null && input.All(Char.IsDigit))
                {
                    var result = Int32.Parse(input);
                    if (result >= 1 && result <= availableIngredients.Count)
                    {
                        addedIngredients.Add(Int32.Parse(input));
                    }
                    else
                    {
                        Console.WriteLine("The added number does not correspond to an ingresient!");
                    }
                }
                else
                {
                    isCompleted = true;
                }
            } while (!isCompleted);

            Console.WriteLine();
            Console.WriteLine("New Recipie added:");
            return addedIngredients;
        }

        public static void PrintNewRecipie(CookieRecipie newRecipie)
        {
            var availableIngredients = AvailableIngredients.GetAvailableIngredients();
            PrintIngredients(newRecipie, availableIngredients);
        }

        public static void PrintExistingRecipies(List<CookieRecipie> recipies)
        {
            var availableIngredients = AvailableIngredients.GetAvailableIngredients();
            Console.WriteLine("Existing recipies: ");
            Console.WriteLine();

            for (var i = 0; i < recipies.Count; i++)
            {
                Console.WriteLine("***** " + (i + 1) + " *****");
                PrintIngredients(recipies[i], availableIngredients);
                Console.WriteLine();
            }
        }

        private static void PrintIngredients(CookieRecipie recipie, List<Ingredient> ingredientList)
        {
            foreach (var ingredient in recipie.Ingredients)
            {
                Console.WriteLine(ingredientList[ingredient - 1].Preparation());
            }
        }
    }
}
