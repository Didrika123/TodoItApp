using System;
using System.Collections.Generic;
using System.Text;

namespace TodoItApp.Model
{
    public class Todo
    {
        readonly int todoId;
        string description;
        bool done;
        Person assignee;

        public int TodoId
        {
            get
            {
                return todoId;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Description cannot be empty.");
                description = value;
            }
        }
        public bool Done
        {
            get
            {
                return done;
            }
            set
            {
                done = value;
            }
        }
        public Person Assignee
        {
            get
            {
                return assignee;
            }
            set
            {
                assignee = value;
            }
        }

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            this.Description = description;
        }
    }
}
