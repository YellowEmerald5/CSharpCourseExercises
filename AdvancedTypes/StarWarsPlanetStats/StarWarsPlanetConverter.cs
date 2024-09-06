using System.Text.Json;

namespace StarWarsPlanetStats
{
    public static class StarWarsPlanetConverter
    {
        public static List<StarWarsPlanet> Convert(string jsonRepresentation)
        {
            var listOfRawPlanets = JsonSerializer.Deserialize<List<StarWarsPlanetRaw>>(jsonRepresentation);
            List<StarWarsPlanet> planets = new();
            if (listOfRawPlanets == null) throw new Exception("Could not convert data from the API to a starwars planet raw data object");
            foreach(var planet in listOfRawPlanets)
            {
                planets.Add(ConvertRawPlanetData(planet));
            }
            return planets;
        }

        private static StarWarsPlanet ConvertRawPlanetData(StarWarsPlanetRaw planet)
        {
            string name = planet.Name;
            int? population = 0;
            int? diameter = 0;
            int? surfaceWater = 0;
            if(planet.Population == null)
            {
                population = null;
            }
            else
            {
                population = planet.Population.Value;
            }
            if (planet.Diameter == null)
            {
                population = null;
            }
            else
            {
                population = planet.Diameter.Value;
            }
            if (planet.SurfaceWater == null)
            {
                population = null;
            }
            else
            {
                surfaceWater = planet.SurfaceWater.Value;
            }
            StarWarsPlanet newPlanetData = new(name, diameter, surfaceWater, population);
            return newPlanetData;
        }
    }
}