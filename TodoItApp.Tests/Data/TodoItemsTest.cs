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


        //Assignment Step 10 Below this comment

        [Fact]
        public void FindByDoneStatus()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();
            todoItems.CreateTodo("A description"); 
            todoItems.CreateTodo("Another description"); 
            Todo[] allTodos = todoItems.FindAll();

            // Act
            allTodos[0].Done = true;
            allTodos[1].Done = false;
            Todo[] doneTodos = todoItems.FindByDoneStatus(true);
            Todo[] notDoneTodos = todoItems.FindByDoneStatus(false);


            // Assert
            Assert.Equal(allTodos[0], doneTodos[0]);
            Assert.Equal(allTodos[1], notDoneTodos[0]);

            // check so there is (1 done) and (1 NOT done)
            Assert.Single(doneTodos);
            Assert.Single(notDoneTodos);
        }


        [Fact]
        public void FindByAssignee()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();
            todoItems.CreateTodo("A description");
            todoItems.CreateTodo("Another description");
            Todo[] allTodos = todoItems.FindAll();

            // Act
            Person person = new Person(12, "Kalle", "Anka");
            allTodos[1].Assignee = person;
            Todo[] assignedTodos = todoItems.FindByAssignee(person); // 2 Birds with 1 stone: findbyassigne(person) calls findbyassigne(personid)

            // Assert
            Assert.Equal(allTodos[1], assignedTodos[0]);

            Assert.Single(assignedTodos);
        }


        [Fact]
        public void FindUnassignedTodos()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();
            todoItems.CreateTodo("A description");
            todoItems.CreateTodo("Another description");
            todoItems.CreateTodo("Anothers description");
            Todo[] allTodos = todoItems.FindAll();

            // Act
            Person person = new Person(12, "Kalle", "Anka");
            allTodos[0].Assignee = person;
            allTodos[1].Assignee = person;
            Todo[] unassignedTodos = todoItems.FindUnassignedTodoItems();

            // Assert
            Assert.Equal(allTodos[2], unassignedTodos[0]);

            Assert.Single(unassignedTodos);
        }


        //Assignment Step 11 Below this comment

        [Fact]
        public void RemoveTodo()
        {
            // Arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();
            todoItems.CreateTodo("A description");
            todoItems.CreateTodo("Another description");
            todoItems.CreateTodo("Good description");
            Todo[] allTodos = todoItems.FindAll();

            // Act
            todoItems.RemoveTodo(allTodos[^1]);
            todoItems.RemoveTodo(allTodos[0]);
            allTodos = todoItems.FindAll();

            // Assert
            Assert.Equal("Another description", allTodos[0].Description);

            Assert.Single(allTodos);
        }
    }
}
