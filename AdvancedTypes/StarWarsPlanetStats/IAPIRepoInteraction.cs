using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats
{
    public interface IAPIRepoInteraction<T>
    {
        public bool IsEmpty();

        public T? GetItem(string nameOfItem);

        public string SearchFor(string searchString);
    }
}
