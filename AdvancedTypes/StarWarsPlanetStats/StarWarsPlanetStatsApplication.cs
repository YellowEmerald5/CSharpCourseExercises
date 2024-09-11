using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWarsPlanetStats.APIInteraction;
using StarWarsPlanetStats.UserInterface;

namespace StarWarsPlanetStats
{
    public class StarWarsPlanetStatsApplication(IAPIRepoInteraction repo, IUserInterface ui)
    {
        private readonly IAPIRepoInteraction repoInteraction = repo;
        private readonly IUserInterface userInterface = ui;

        public void Run()
        {
            repoInteraction.ToString();
            string planetsAsStringTable = repoInteraction.GetRepositoryAsString();
            userInterface.DisplayPlanetDataForAllPLanets(planetsAsStringTable);
            string searchString = userInterface.GetSearchString();
            repoInteraction.SearchFor(searchString);
        }
    }
}