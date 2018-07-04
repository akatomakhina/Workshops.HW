using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakExample
{
    public class Static
    {
        private static List<Person> listOfPerson = new List<Person>();

        public static Person CreatePerson(string name, int age, string position)
        {
            var person = new Person(name, age, position);
            listOfPerson.Add(person);            
            return person;
        }
    }

    public class Person
    {
        private string name;
        private int age;
        private string position;

        public Person()
        {

        }

        public Person(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }

        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }        

        public string Position
        {
            get;
            set;
        }
    }
}
