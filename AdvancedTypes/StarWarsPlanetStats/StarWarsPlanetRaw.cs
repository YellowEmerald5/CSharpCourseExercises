using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats
{
    public class StarWarsPlanetRaw
    {
            public string Name { get; init; }
            public string Rotation_period { get; set; }
            public string Orbital_period { get; set; }
            public string Diameter { get; set; }
            public string Climate { get; set; }
            public string Gravity { get; set; }
            public string Terrain { get; set; }
            public string SurfaceWater { get; set; }
            public string Population { get; set; }
            public IList<string> Residents { get; set; }
            public IList<string> Films { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public DateTime Url { get; set; }
    }
}
