using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats
{
    public class StarWarsPlanet
    {
        public string Name { get; init; }
        public int? Diameter { get; init; }
        public int? SurfaceWater { get; init; }
        public int? Population { get; init; }

        public StarWarsPlanet(string name, int? diameter, int? surfaceWater, int? population)
        {
            Name = name;
            Diameter = diameter;
            SurfaceWater = surfaceWater;
            Population = population;
        }
    }
}
