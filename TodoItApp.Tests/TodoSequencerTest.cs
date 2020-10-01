using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Data;

namespace TodoItApp.Tests
{
    public class TodoSequencerTest
    {
        [Fact]
        public void TodoIdCountsUp()
        {
            // Arrange
            int oldvalue = TodoSequencer.NextTodoId();
            int expected = oldvalue + 1;

            // Act
            int result = TodoSequencer.NextTodoId();

            // Asssert

            Assert.Equal(expected, result);

        }

        [Fact]
        public void TodoIdCountUpResets()
        {
            // Arrange
            int expected = 1;
            for (int i = 0; i < 67; i++) //Just count up a bunch of times 
                TodoSequencer.NextTodoId();

            // Act
            TodoSequencer.Reset();
            int result = TodoSequencer.NextTodoId();

            // Asssert
            Assert.Equal(expected, result);

        }
    }
}
