using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibility
{
    public class Todo
    {
        public Todo()
        {
            Todo._id++;
            Id = Todo._id;
            Category = Category.Other;
            Description = string.Empty;
        }

        public Todo(string description)
        {
            Todo._id++;
            Id = Todo._id;
            Category = Category.Other;
            Priority = Priority.Low;
            Description = description ?? throw new ArgumentNullException("Description parameter must be entered");
        }

        public Todo(Category category, Priority priority, string description)
        {
            Todo._id++;
            Id = Todo._id;
            Category = category;
            Priority = priority;
            Description = description ?? throw new ArgumentNullException("Description parameter must be entered");
        }

        private static int _id = 0;
        public int Id { get; private set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public string Description { get; set; }
    }

    public enum Category
    {
        Work,
        Hobby, 
        Home,
        Other
    }

    public enum Priority
    {
        Low,
        Medium,
        Major
    }
}
