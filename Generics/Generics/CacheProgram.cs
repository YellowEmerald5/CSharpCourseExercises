using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class CacheProgram
    {
        private IUserInterface _ui;
        public CacheProgram(IUserInterface ui) {
            _ui = ui;
        }
        public void Run()
        {
            Person person1 = new Person(1,"Ben",30);
            Person person2 = new Person(2, "Gen", 45);
            Person person3 = new Person(3, "Sen", 60);
            var cache = new CustomCacheType<string, int>();

            var id = person1.GetID();
            var name = person1.Name;
            cache.EnterValue(name, id);
            _ui.PrintValues(id + "");
            id = person2.GetID();
            name = person2.Name;
            cache.EnterValue(name, id);
            _ui.PrintValues(id+"");
            id = person3.GetID();
            name = person3.Name;
            cache.EnterValue(name, id);
            _ui.PrintValues(id + "");

            var result = cache.TryGetValue(person1.Name);
            if (result.Item1)
            {
                _ui.PrintValues(result.Item2 + "");
            }
            result = cache.TryGetValue(person2.Name);
            if (result.Item1)
            {
                _ui.PrintValues(result.Item2 + "");
            }
            result = cache.TryGetValue(person3.Name);
            if (result.Item1)
            {
                _ui.PrintValues(result.Item2 + "");
            }
            Console.ReadLine();
        }
    }
}
