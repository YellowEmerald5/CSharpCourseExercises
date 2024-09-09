using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.UserInterface
{
    public interface IUserInterface
    {
        string GetSearchString();
        void DisplayPlanetDataForAllPLanets(string planetsRepresentedAsStrings);
        void DisplaySearchData(string searchResults);
    }
}
