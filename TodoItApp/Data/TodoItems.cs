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

        //Assignment Step 10 Below this comment
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] result = new Todo[0];
            foreach (var item in todoArray)
            {
                if (item.Done == doneStatus)
                {
                    Array.Resize<Todo>(ref result, result.Length + 1);
                    result[^1] = item;  // Wow an index operator!
                    //result[result.Length - 1] = item;
                }
            }
            return result;

            //return Array.FindAll(todoArray, n => n.Done == doneStatus);
        }
        public Todo[] FindByAssignee(int personId)
        {
            return Array.FindAll(todoArray, n => n.Assignee != null && n.Assignee.PersonId == personId);
        }
        public Todo[] FindByAssignee(Person assignee)
        {
            return FindByAssignee(assignee.PersonId);
        }
        public Todo[] FindUnassignedTodoItems()
        {
            return Array.FindAll(todoArray, n => n.Assignee == null);
        }


        // Assignment Step 11 Below this comment

        public void RemoveTodo(Todo todo)
        {
            for (int i = 0; i < todoArray.Length; i++)
            {
                if (todoArray[i] == todo)
                {
                    todoArray[i] = todoArray[todoArray.Length - 1]; //Move last element to the index of the one to be removed.
                    Array.Resize<Todo>(ref todoArray, todoArray.Length - 1); //Remove the last item 
                }
            }

            //todoArray = Array.FindAll<Todo>(todoArray, n => n != todo);
        }
        /*
         A SIDE NOTE

         We might want to clear assigness when removing Persons from the system, Solutions:

         1. static RemoveAssigne() in this class which is called from the remove method of the people class 

         2. Maybe a better solution would be a wrapper with People & Todoitems that handles clearing a person (From both TodoItems:assignees & People)

         3. You check inside the Todo class Property of assignee(the get method) you add a check that checks if the assignee exists in People

         4. You check here every time you use assignee if that assigne is present in the people class

         5. You dont clear assignees at all and let them reference a person that isnt present inside People

         6. An option I'm unaware of that is superior to all other?


         - I believe - 

         Option 3, 4 are bad because it introduces some ugly dependencies. Why? Because they don't have any relation to the People class.
         Option 1 is bad because ugly dependency too, because the People class have no relation to the TodoItems class (this class)

         Option 2 is the best option if you want the functionality that assignees are to be cleared upon removal of a person from the system. Since it doesnt introduce weird relations.
         Option 5 is the best option if you DONT want the functionality that assingees are cleared upon removal of person from the system
         

         - Conclusion -
         Since the assignments states that we shouldnt add extra things I just picked the easiest option to implement: 
         Option: Nr 5, we assume the intended functionality is that asignees are not cleared upon removal of person.

         - Bonus -

         I implemented option 1 below.

        */
        public static void RemoveAssignee(Person assignee)
        {
            foreach (var item in todoArray)
            {
                if (item.Assignee == assignee)
                {
                    item.Assignee = null;
                }
            }
        }
    }
}
