using System;
using TodoItApp.Model;
using Xunit;

namespace TodoItApp.Tests
{
    public class PersonTest
    {
        [Theory]
        [InlineData(null, "GoodName")]
        [InlineData("", "GoodName")]
        [InlineData("  ", "GoodName")]
        [InlineData("GoodName", null)]
        [InlineData("GoodName", "")]
        [InlineData("GoodName", "  ")]
        public void BadNameConstructor(string firstName, string lastName)
        {
            //Arrange
            int personId = 215;

            //Act & assert
            Assert.Throws<ArgumentException>(() => new Person(personId, firstName, lastName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BadFirstNameProperty(string firstName)
        {
            //Arrange
            int goodId = 0;
            Person aPerson = new Person(goodId, "GoodName", "GoodName");

            //Act & assert
            Assert.Throws<ArgumentException>(() => aPerson.FirstName = firstName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void BadLastNameProperty(string lastName)
        {
            //Arrange
            int goodId = 0;
            Person aPerson = new Person(goodId, "GoodName", "GoodName");

            //Act & assert
            Assert.Throws<ArgumentException>(() => aPerson.LastName = lastName);
        }
    }
}
