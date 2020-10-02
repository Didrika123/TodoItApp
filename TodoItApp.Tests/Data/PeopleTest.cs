using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Data;
using TodoItApp.Model;

namespace TodoItApp.Tests
{
    public class PeopleTest
    {
        [Fact]
        public void TestSizeCountsUp()
        {
            // Arrange
            People people = new People();
            int oldSize = people.Size();
            int expected = oldSize + 1;

            // Act
            people.CreatePerson("GoodName", "GoodName");
            int newSize = people.Size();

            // Assert
            Assert.Equal(expected, newSize);
        }

        [Fact]
        public void FindAll_ReturnsThePeopleWeAdded()
        {
            // Arrange
            People people = new People();
            people.Clear(); //Make sure its cleared, since People maintains a static array field to contain persons
            string firstName = "Kalle";
            string lastName = "Andersson";
            people.CreatePerson(firstName, lastName);

            // Act
            Person kalle = people.FindAll()[0]; //Pick him out again

            // Assert
            Assert.Equal(firstName, kalle.FirstName);
            Assert.Equal(lastName, kalle.LastName);

        }

        [Fact]
        public void FindById_ReturnsThePersonWithSameId()
        {
            // Arrange
            People people = new People();
            people.Clear(); //Make sure its cleared, since People maintains a static array field to contain persons
            string firstName = "Kalle";
            string lastName =  "Andersson";
            people.CreatePerson(firstName, lastName);
            Person kalle = people.FindAll()[0]; //Pick him out again

            // Act
            Person foundPerson = people.FindById(kalle.PersonId);

            // Assert
            Assert.Equal(kalle, foundPerson);

        }

        [Fact]
        public void FindById_GivenNonExistingId_ReturnsNull()
        {
            // Arrange
            People people = new People();
            people.Clear(); //Make sure its cleared, since People maintains a static array field to contain persons
            people.CreatePerson("Kalle", "Goodname");
            Person kalle = people.FindAll()[0]; //Pick him out again
            int nonExistingPersonId = kalle.PersonId + 54;

            // Act
            Person foundPerson = people.FindById(nonExistingPersonId);

            // Assert
            Assert.Null(foundPerson);

        }

        [Fact]
        public void CreatePersonAddsPerson()
        {
            // Arrange
            People people = new People();
            people.Clear(); //Make sure its cleared, since People maintains a static array field to contain persons
            string firstName = "Kalle";
            string lastName = "Andersson";

            // Act
            people.CreatePerson(firstName, lastName);
            Person kalle = people.FindAll()[0]; //Pick him out again

            // Assert
            Assert.Equal(firstName, kalle.FirstName);
            Assert.Equal(lastName, kalle.LastName);

        }

        [Fact]
        public void ClearSetsSizeToZeroAndRemovesAllPeople()
        {
            // Arrange
            People people = new People();
            people.CreatePerson("GoodName", "GoodName");
            people.CreatePerson("GooderName", "GooderName");
            people.CreatePerson("GoodestName", "GoodestName");
            int expectedSize = 0;

            // Act
            people.Clear();
            int sizeAfterClear = people.Size();
            int findAllArraySizeAfterClear = people.FindAll().Length;

            // Assert
            Assert.Equal(expectedSize, sizeAfterClear);
            Assert.Equal(expectedSize, findAllArraySizeAfterClear);

        }
    }
}
