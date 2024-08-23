namespace GameDataParserApp
{
    public class Logger
    {
        private readonly string filePath = "ErrorLog.txt";
        public Logger()
        {

        }
        public void Log(Exception ex)
        {
            StreamWriter fileWriter = new(filePath,true);
            var date = DateTime.Now;
            fileWriter.WriteLine("[" + date + "]" +"\n" + ex.Message + "\n" + ex.StackTrace);
            fileWriter.Close();
        }
    }
}