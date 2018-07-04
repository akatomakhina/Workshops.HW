using MemoryLeakExample;
using System;

namespace ConsoleTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var manager = new MailManager();
            var fax = new Fax();
            fax.Register(manager);            

            manager.SimulateNewMail("Minsk", "Riga", "Letter");

            Console.WriteLine();

            fax = null; // Не освобождается

            manager.SimulateNewMail("Warsawa", "Minsk", "SMS");

            var person = new Person();
            person = Static.CreatePerson("Nastichka", 20, "Student");
            Console.WriteLine(person);

            Console.ReadKey();
        }
    }
}
