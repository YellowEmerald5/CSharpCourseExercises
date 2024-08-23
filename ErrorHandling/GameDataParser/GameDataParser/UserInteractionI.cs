using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParserApp
{
    public interface UserInteractionI
    {
        string UserInput();
        void ErrorsInFileInteraction();
        void IncorrectFormat(JsonException jsonException);
        void PrintGameInfo(List<Game> games);
        string InputLoop(string inputInformation);
    }
}
