using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.APIInteraction
{
    public interface IAPIRepoInteraction
    {
        public bool IsEmpty();

        public void SearchFor(string searchString);

        public string GetRepositoryAsString();
    }
}
