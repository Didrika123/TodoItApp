using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Data;
using TodoItApp.Model;

//Because we have a static array field that we use it can mess up tests if they run in parallel, so lets disable parallel test running :O
[assembly: CollectionBehavior(DisableTestParallelization = true)]

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


        //Assignment Step 11 Below this comment

        [Fact]
        public void RemovePerson()
        {
            // Arrange
            People people = new People();
            people.Clear();
            people.CreatePerson("Kalle", "Planka");
            people.CreatePerson("Marley", "Moster");
            people.CreatePerson("Michael", "Kennedy");
            Person[] allPersons = people.FindAll();

            // Act
            people.RemovePerson(allPersons[^1]);
            people.RemovePerson(allPersons[0]);
            allPersons = people.FindAll();

            // Assert
            Assert.Equal("Marley", allPersons[0].FirstName);

            Assert.Single(allPersons);
        }

        // Bonus test
        [Fact]
        public void RemovePersonAndClearAssignees()
        {
            // Arrange
            People people = new People();
            people.Clear();
            people.CreatePerson("Kalle", "Planka");
            people.CreatePerson("Marley", "Moster");
            people.CreatePerson("Michael", "Kennedy");
            Person[] allPersons = people.FindAll();

            TodoItems todoItems = new TodoItems();
            todoItems.Clear();
            todoItems.CreateTodo("A description");
            todoItems.CreateTodo("Another description");
            todoItems.CreateTodo("Good description");
            Todo[] allTodos = todoItems.FindAll();

            // Act
            allTodos[0].Assignee = allPersons[0];
            allTodos[1].Assignee = allPersons[1];
            allTodos[2].Assignee = allPersons[2];
            people.RemovePerson(allPersons[^1]);
            todoItems.RemoveAssignee(allPersons[^1]);
            people.RemovePerson(allPersons[0]);
            todoItems.RemoveAssignee(allPersons[0]);
            allPersons = people.FindAll();

            // Assert
            Assert.Null(allTodos[0].Assignee);
            Assert.Equal(allTodos[1].Assignee, allPersons[0]);
            Assert.Null(allTodos[2].Assignee);

            Assert.Single(allPersons);
        }
    }
}
