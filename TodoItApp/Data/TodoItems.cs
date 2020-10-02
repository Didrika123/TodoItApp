using System;
using System.Collections.Generic;
using System.Text;
using TodoItApp.Model;

namespace TodoItApp.Data
{
    public class TodoItems
    {
        static Todo[] todoArray = new Todo[0];
        public int Size()
        {
            return todoArray.Length;
        }

        public Todo[] FindAll()
        {
            return todoArray;
        }

        public Todo FindById(int todoId)
        {
            foreach (var todo in todoArray)
            {
                if (todo.TodoId == todoId)
                    return todo;
            }

            return null;
            //return Array.Find<Todo>(todos, n => n.TodoId == todoId);
        }

        public void CreateTodo(string desc)
        {
            //Create a new array with a bigger size to fit in the new todo
            int newLength = todoArray.Length + 1;
            Array.Resize<Todo>(ref todoArray, newLength);

            //Add a todo at the end of the newly resized array
            int todoId = TodoSequencer.NextTodoId();
            todoArray[newLength - 1] = new Todo(todoId, desc);
        }
        public void Clear()
        {
            todoArray = new Todo[0];
        }
        
    }
}
