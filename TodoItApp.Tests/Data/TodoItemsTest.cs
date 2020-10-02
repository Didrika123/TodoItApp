using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TodoItApp.Data;
using TodoItApp.Model;

namespace TodoItApp.Tests.Data
{
    public class TodoItemsTest
    {
        [Fact]
        public void TestSizeCountsUp()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            int oldSize = todoItems.Size();
            int expected = oldSize + 1;

            // Act
            todoItems.CreateTodo("Good Description");
            int newSize = todoItems.Size();

            // Assert
            Assert.Equal(expected, newSize);
        }

        [Fact]
        public void FindAll_ReturnsTheTodoItemsWeAdded()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear(); //Make sure its cleared, since TodoItems maintains a static array field to contain todos
            string desc = "A description";
            todoItems.CreateTodo(desc);

            // Act
            Todo todo = todoItems.FindAll()[0]; //Pick it out again

            // Assert
            Assert.Equal(desc, todo.Description);

        }

        [Fact]
        public void FindById_ReturnsTheTodoWithSameId()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear(); //Make sure its cleared, since TodoItems maintains a static array field to contain todos
            string desc = "A description";
            todoItems.CreateTodo(desc);
            Todo expectedTodo = todoItems.FindAll()[0]; //Pick it out again

            // Act
            Todo foundTodo = todoItems.FindById(expectedTodo.TodoId);

            // Assert
            Assert.Equal(expectedTodo, foundTodo);

        }

        [Fact]
        public void FindById_GivenNonExistingId_ReturnsNull()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear(); //Make sure its cleared, since TodoItems maintains a static array field to contain todos
            todoItems.CreateTodo("A good description");
            Todo todo = todoItems.FindAll()[0]; //Pick it out again
            int nonExistingTodoId = todo.TodoId + 54;

            // Act
            Todo foundTodo = todoItems.FindById(nonExistingTodoId);

            // Assert
            Assert.Null(foundTodo);
        }

        [Fact]
        public void CreateTodoAddsTodo()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear(); //Make sure its cleared, since TodoItems maintains a static array field to contain todos
            string desc = "A good description";

            // Act
            todoItems.CreateTodo(desc);
            Todo actualTodo = todoItems.FindAll()[0]; //Pick it out again

            // Assert
            Assert.Equal(desc, actualTodo.Description);
        }

        [Fact]
        public void ClearSetsSizeToZeroAndRemovesAllTodoItems()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.CreateTodo("Good Description");
            todoItems.CreateTodo("A Gooder Description");
            todoItems.CreateTodo("The Goodest Description");
            int expectedSize = 0;

            // Act
            todoItems.Clear();
            int sizeAfterClear = todoItems.Size();
            int findAllArraySizeAfterClear = todoItems.FindAll().Length;

            // Assert
            Assert.Equal(expectedSize, sizeAfterClear);
            Assert.Equal(expectedSize, findAllArraySizeAfterClear);

        }
    }
}
