using System;
using TodoItApp.Model;
using Xunit;

namespace TodoItApp.Tests
{
    public class PersonTest
    {
        [Fact]
        public void NameNotNull()
        {
            //Arrange
            string firstName = "Kalle";
            string lastName = "Anka";
            Person aPerson = new Person(294, firstName, lastName);

            //Act
            aPerson.LastName = "";
            aPerson.LastName = null;
            aPerson.FirstName = "";
            aPerson.FirstName = null;

            //Assert
            Assert.Equal(firstName, aPerson.FirstName);
            Assert.Equal(lastName, aPerson.LastName);
        }
    }
}
