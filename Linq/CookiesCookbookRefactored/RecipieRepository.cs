using CookiesCookbookRefactored.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookiesCookbookRefactored
{
    public class RecipieRepository
    {
        private AvailableIngredients _availableIngredients = new();
        public List<CookieRecipie> Repository { get; set; }

        public RecipieRepository(string fileName)
        {
            Repository = FileHandler.ReadFromFile(fileName).Select(CookieRecipieFromString).ToList();
        }

        private CookieRecipie CookieRecipieFromString(string recipieAsJsonString)
        {
            var recipie = JsonSerializer.Deserialize<CookieRecipie>(recipieAsJsonString);
            recipie.Ingredients = recipie.Ingredients.Select(ingredient => _availableIngredients.GetIngredientByID(ingredient.Id)).ToList();
            return recipie;
        }

        public void Add(CookieRecipie recipie)
        {
            Repository.Add(recipie);
        }

        public void WriteRecipiesToFile(string fileName)
        {
            var recipiesAsJsonStrings = Repository.Select(recipie => JsonSerializer.Serialize(recipie)).ToList();
            FileHandler.WriteToFile(recipiesAsJsonStrings, fileName);
        }
    }
}
