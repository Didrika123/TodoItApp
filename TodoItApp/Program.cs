using System;
using TodoItApp.Model;

namespace TodoItApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p;


            Person[] personArray = new Person[3];
            personArray[0] = new Person(123, "Kalle", "Karlsson");
            personArray[1] = new Person(321, "Niklas", "Borjeson");
            personArray[2] = new Person(444, "Gustav", "Areaa");

            foreach (Person person in personArray)
            {
                Console.WriteLine(person.FirstName);
            }
            Console.ReadLine();
        }
    }
}
