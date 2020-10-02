﻿using System;
using System.Collections.Generic;
using System.Text;
using TodoItApp.Model;

namespace TodoItApp.Data
{
    public class People
    {
        static Person[] personArray = new Person[0];
        
        public int Size()
        {
            return personArray.Length;
        }

        public Person[] FindAll()
        {
            return personArray;
        }

        public Person FindById(int personId)
        {
            foreach (var person in personArray)
            {
                if (person.PersonId == personId)
                    return person;
            }

            return null;
            //return Array.Find<Person>(persons, n => n.PersonId == personId);
        }

        public void CreatePerson(string firstName, string lastName)
        {
            //Create a new array with a bigger size to fit in the new person
            int newLength = personArray.Length + 1;
            Array.Resize<Person>(ref personArray, newLength);

            //Add a person at the end of the newly resized array
            int personId = PersonSequencer.NextPersonId(); 
            personArray[newLength - 1] = new Person(personId, firstName, lastName);
        }
        public void Clear()
        {
            personArray = new Person[0];
        }
    }
}
