using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItApp.Data
{
    public class TodoSequencer
    {
        static int todoId;
        public static int NextTodoId()
        {
            return ++todoId;
        }
        public static void Reset()
        {
            todoId = 0;
        }
    }
}
