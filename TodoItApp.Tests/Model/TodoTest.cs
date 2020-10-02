using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Model;

namespace TodoItApp.Tests
{
    public class TodoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BadDescriptionConstructor(string desc)
        {
            //arrange
            int id = 0;
            //act & assert
            Assert.Throws<ArgumentException>(() => new Todo(id, desc));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void BadDescriptionProperty(string desc)
        {
            //arrange
            Todo todo = new Todo(0, "Good Description");
            //act & assert
            Assert.Throws<ArgumentException>( () => todo.Description = desc );
        }
    }
}
