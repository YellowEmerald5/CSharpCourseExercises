using CookiesCookbookRefactored.Ingredients;
using System;
using System.Text.Json;

namespace CookiesCookbookRefactored
{
    public static class FileHandler
    {
        public static void WriteToFile(List<string> objectsAsJsonStrings, string file)
        {

            StreamWriter fileWriter = new(file);
            fileWriter.Write(string.Join(Environment.NewLine,objectsAsJsonStrings));
            fileWriter.Close();
        }
        public static List<string> ReadFromFile(string file)
        {
            var result = new List<string>();
            StreamReader reader;
            try
            {
                reader = new(file);
            }
            catch (Exception ex)
            {
                return result;
            }
            var jsonString = "";
            do
            {
                jsonString = reader.ReadLine();
                if(jsonString != null) result.Add(jsonString);
            } while (jsonString != null);
            reader.Close();
            return result;
        }
    }
}
