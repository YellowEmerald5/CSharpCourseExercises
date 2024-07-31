using System;
using System.Text.Json;

namespace CookiesCookbook
{
    public static class FileHandler
    {
        public static void WriteToFile(List<CookieRecipie> recipies, string file) {

            
            StreamWriter fileWriter = new(file);
            foreach (var recipie in recipies)
            {
                var recipieAsJson = JsonSerializer.Serialize(recipie);
                fileWriter.WriteLine(recipieAsJson);
            }
            fileWriter.Close();
        }
        public static List<CookieRecipie> ReadFromFile(string file) {
            var recipies = new List<CookieRecipie>();
            StreamReader reader;
            try
            {
                reader = new(file);
            }
            catch (Exception ex) {
                return recipies;
            }
            var jsonString = "";
            do
            {
                jsonString = reader.ReadLine();
                if (jsonString != null)
                {
                    recipies.Add(JsonSerializer.Deserialize<CookieRecipie>(jsonString));
                }
            } while (jsonString != null);
            reader.Close();
            return recipies;
        }
    }
}
