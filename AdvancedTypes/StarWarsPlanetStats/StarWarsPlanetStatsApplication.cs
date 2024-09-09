using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsPlanetStats.APIInteraction;
using StarWarsPlanetStats.UserInterface;

namespace StarWarsPlanetStats
{
    public class StarWarsPlanetStatsApplication
    {
        private IAPIRepoInteraction repoInteraction;
        private IUserInterface userInterface;

        public StarWarsPlanetStatsApplication(IAPIRepoInteraction repo, IUserInterface ui)
        {
            repoInteraction = repo;
            userInterface = ui;
        }

        public void Run()
        {
            repoInteraction.ToString();
            string planetsAsStringTable = repoInteraction.GetRepositoryAsString();
            userInterface.DisplayPlanetDataForAllPLanets(planetsAsStringTable);
            string searchString = userInterface.GetSearchString();
            string result = repoInteraction.SearchFor(searchString);
            userInterface.DisplaySearchData(result);
        }
    }
}