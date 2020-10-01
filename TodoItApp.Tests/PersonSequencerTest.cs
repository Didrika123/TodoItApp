using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Data;

namespace TodoItApp.Tests
{
    public class PersonSequencerTest
    {
        [Fact]
        public void PersonIdCountsUp()
        {
            //arrange
            int previousValue = PersonSequencer.NextPersonId();
            int expected = previousValue + 1;

            //act
            int result = PersonSequencer.NextPersonId();

            //assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void PersonIdCountUpResets()
        {
            //Arrange
            int expected = 1;
            for (int i = 0; i < 10; i++) //just count up a bunch of persons
                PersonSequencer.NextPersonId();

            //Act
            PersonSequencer.Reset();
            int result = PersonSequencer.NextPersonId();

            //Assert
            Assert.Equal(expected, result);


        }
    }
}
