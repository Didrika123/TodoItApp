using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItApp.Model
{
    public class Person
    {
        // fields
        private readonly int personId;
        private string firstName = "John";
        private string lastName = "Doe";

        // Properties
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

        // Constructor
        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
