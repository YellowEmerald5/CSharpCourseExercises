using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class CookieRecipiebook
    {
        private readonly IUserInteraction _userInteraction;

        public CookieRecipiebook(IUserInteraction userInteraction)
        {
            _userInteraction = userInteraction;
        }

        private static string filePath = "CookieRecipiebook.json";
        public void Run()
        {
            var recipies = FileHandler.ReadFromFile(filePath);
            if (recipies.Count > 0)
            {
                _userInteraction.PrintExistingRecipies(recipies);
            }

            var addedIngredients = _userInteraction.InputForNewRecipie();
            if (addedIngredients.Count > 0) {
                var newRecipie = new CookieRecipie([.. addedIngredients]);
                _userInteraction.PrintNewRecipiePreparation(newRecipie);
                recipies.Add(newRecipie);
                FileHandler.WriteToFile(recipies, filePath);
            }
        }

        
    }
}
