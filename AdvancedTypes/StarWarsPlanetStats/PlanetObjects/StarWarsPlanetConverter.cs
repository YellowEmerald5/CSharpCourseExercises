using System.Text.Json;

namespace StarWarsPlanetStats.PlanetObjects
{
    public static class StarWarsPlanetConverter
    {
        public static List<StarWarsPlanet> Convert(string jsonRepresentation)
        {
            var listOfRawPlanets = JsonSerializer.Deserialize<Root>(jsonRepresentation);
            List<StarWarsPlanet> planets = [];
            if (listOfRawPlanets == null) throw new Exception("Could not convert data from the API to a starwars planet raw data object");
            foreach (var planet in listOfRawPlanets.Results)
            {
                planets.Add(ConvertRawPlanetData(planet));
            }
            return planets;
        }

        private static StarWarsPlanet ConvertRawPlanetData(Result planet)
        {
            string name = planet.Name;
            long? population = planet.Population.StringToNullableLong();
            long? diameter = planet.Diameter.StringToNullableLong();
            long? surfaceWater = planet.SurfaceWater.StringToNullableLong();
            StarWarsPlanet newPlanetData = new(name, diameter, surfaceWater, population);
            return newPlanetData;
        }

        private static long? StringToNullableLong(this string str)
        {
            var result = long.TryParse(str,out long value);
            if(!result)
            {
                return null;
            }
            return value;
        }
    }
}