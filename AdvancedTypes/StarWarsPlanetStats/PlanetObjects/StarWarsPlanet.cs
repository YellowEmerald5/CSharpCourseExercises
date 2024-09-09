using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.PlanetObjects
{
    public class StarWarsPlanet
    {
        public string Name { get; init; }
        public long? Diameter { get; init; }
        public long? SurfaceWater { get; init; }
        public long? Population { get; init; }

        public StarWarsPlanet(string name, long? diameter, long? surfaceWater, long? population)
        {
            Name = name;
            Diameter = diameter;
            SurfaceWater = surfaceWater;
            Population = population;
        }

        public override string ToString()
        {
            var diameter = "";
            if (Diameter != null)
            {
                diameter = Diameter.ToString();
            }
            var surfaceWater = "";
            if (SurfaceWater != null)
            {
                surfaceWater = SurfaceWater.ToString();
            }
            var population = "";
            if (Population != null)
            {
                population = Population.ToString();
            }
            string result = $"{Name.PadRight(15)}|{diameter.PadRight(15)}|{surfaceWater.PadRight(15)}|{population.PadRight(15)}|";
            return result;
        }
    }
}
