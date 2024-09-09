using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.UserInterface
{
    public class ConsoleUI : IUserInterface
    {
        public void DisplayPlanetDataForAllPLanets(string planetsRepresentedAsStrings)
        {
            Console.WriteLine(planetsRepresentedAsStrings);
        }

        public void DisplaySearchData(string searchResults)
        {
            Console.WriteLine(searchResults);
            Console.ReadKey();
        }

        public string GetSearchString()
        {
            Console.WriteLine("Select the statistics you are interested in: \npopulation\ndiameter\nsurface water");
            var searchString = Console.ReadLine();
            while (searchString == null)
            {
                Console.WriteLine("Incorrect search word. Please write a valid search string");
                searchString = Console.ReadLine();
            }
            return searchString;
        }
    }
}
