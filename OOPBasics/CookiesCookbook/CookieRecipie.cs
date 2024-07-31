using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class CookieRecipie
    {
        public int[] Ingredients { get; init; }
        public CookieRecipie(int[] ingredients) {
            Ingredients = ingredients;
        }
    }
}
