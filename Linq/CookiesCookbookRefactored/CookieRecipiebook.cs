using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
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
            var recipieRepository = new RecipieRepository(filePath);
            if (recipieRepository.Repository.Count > 0)
            {
                _userInteraction.PrintExistingRecipies(recipieRepository.Repository);
            }

            var addedIngredients = _userInteraction.InputForNewRecipie();
            if (addedIngredients.Count > 0) {
                var newRecipie = new CookieRecipie([.. addedIngredients]);
                _userInteraction.PrintNewRecipiePreparation(newRecipie);
                recipieRepository.Add(newRecipie);
                recipieRepository.WriteRecipiesToFile(filePath);
            }
            Console.ReadKey();
        }

        
    }
}
