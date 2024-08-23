using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class Person
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Age { get; init; }

        public Person(int id, string name, int age) {
            Id = id;
            Name = name;
            Age = age;
        }

        public int GetID() {
            Thread.Sleep(1000);
            return Id;
        }
    }
}
