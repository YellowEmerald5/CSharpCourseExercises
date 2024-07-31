using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public static class CookieRecipiebook
    {

        private static string filePath = "CookieRecipiebook.json";
        public static void Run()
        {
            var recipies = FileHandler.ReadFromFile(filePath);

            if (recipies.Count > 0)
            {
                ConsoleUI.PrintExistingRecipies(recipies);
            }

            var addedIngredients = ConsoleUI.RecipieInput();
            var newRecipie = new CookieRecipie([.. addedIngredients]);
            ConsoleUI.PrintNewRecipie(newRecipie);
            recipies.Add(newRecipie);
            FileHandler.WriteToFile(recipies, filePath);
            Console.ReadKey();
        }

        
    }
}
