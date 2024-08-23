using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParserApp
{
    public class GameDataParser
    {
        private UserInteractionI ui;

        public GameDataParser(UserInteractionI ui)
        {
            this.ui = ui;
        }

        public void Run()
        {
            var logger = new Logger();
            var fileName = ui.UserInput();
            var state = false;
            while (!state)
            {
                try
                {
                    var games = FileHandler.ReadFromFile(fileName);
                    ui.PrintGameInfo(games);
                    state = true;
                }
                catch (FileNotFoundException ex)
                {
                    ui.ErrorsInFileInteraction();
                    fileName = ui.UserInput();
                    logger.Log(ex);
                }
                catch (JsonException ex)
                {
                    ui.IncorrectFormat(ex);
                    logger.Log(ex);
                    break;
                }
            }
        }
    }
}
