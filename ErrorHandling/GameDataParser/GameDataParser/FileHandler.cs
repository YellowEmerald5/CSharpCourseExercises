using System;
using System.Text.Json;

namespace GameDataParserApp
{
    public static class FileHandler
    {
        public static void WriteToFile(List<Game> itemList, string file)
        {

            StreamWriter fileWriter = new(file);
            foreach (var recipie in itemList)
            {
                var recipieAsJson = JsonSerializer.Serialize(recipie);
                fileWriter.WriteLine(recipieAsJson);
            }
            fileWriter.Close();
        }
        public static List<Game> ReadFromFile(string file)
        {
            var games = new List<Game>();
            string jsonString = File.ReadAllText(file);


            if (jsonString != null)
            {
                try
                {
                    games = JsonSerializer.Deserialize<List<Game>>(jsonString);
                    
                }
                catch (JsonException ex)
                {
                    throw new JsonException(jsonString);
                }

            }
            return games;
        }
    }
}
