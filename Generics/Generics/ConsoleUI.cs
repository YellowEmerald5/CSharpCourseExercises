using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class ConsoleUI : IUserInterface
    {
        public void PrintValues(string str)
        {
            Console.WriteLine(str);
        }
    }
}
