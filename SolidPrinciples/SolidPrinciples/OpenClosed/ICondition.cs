using SolidPrinciples.SingleResponsibility;
using System;
using System.Collections.Generic;

namespace SolidPrinciples.OpenClosed
{
    public interface ICondition<TObject>
        where TObject : class
    {
        /// <summary>
        /// Check if the object met condition.
        /// </summary>
        /// <param name="item">Object on which we are checking conditions.</param>
        bool IsSatisfied(TObject item);
    }

    public class PriorityCondition : ICondition<Todo>
    {
        public Priority Priority { get; private set; }

        public PriorityCondition(Priority priority)
        {
            Priority = priority;
        }

        public bool IsSatisfied(Todo todo)
        {
            return todo.Priority == Priority;
        }
    }
    public class CategoryCondition : ICondition<Todo>
    {
        public Category Category { get; private set; }

        public CategoryCondition(Category category)
        {
            Category = category;
        }

        public bool IsSatisfied(Todo todo)
        {
            return todo.Category == Category;
        }
    }
}
