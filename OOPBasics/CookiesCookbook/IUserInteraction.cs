using CookiesCookbook.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public interface IUserInteraction
    {
        List<Ingredient> InputForNewRecipie();
        void PrintNewRecipiePreparation(CookieRecipie newRecipie);
        void PrintExistingRecipies(List<CookieRecipie> recipies);
    }
}
