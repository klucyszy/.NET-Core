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
            Description = description;
        }

        public Todo(Category category, string description)
        {
            Todo._id++;
            Id = Todo._id;
            Category = category;
            Description = description;
        }

        private static int _id = 0;
        public int Id { get; private set; }
        public Category Category { get; set; }
        public string Description { get; set; }
    }

    public enum Category
    {
        Work,
        Hobby, 
        Home,
        Other
    }
}
