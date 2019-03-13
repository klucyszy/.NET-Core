using SolidPrinciples.SingleResponsibility;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolidPrinciples.OpenClosed
{
    public interface IFilter<TObject>
        where TObject : class
    {
        /// <summary>
        /// Items to be filterd.
        /// </summary>
        IEnumerable<TObject> ItemsToBeFiltered { get; set; }
        
        /// <summary>
        /// Conditions to be met.
        /// </summary>
        IEnumerable<ICondition<TObject>> Conditions { get; set; }

        /// <summary>
        /// Check if specific objects meets all conditions.
        /// </summary>
        /// <param name="item">Todo item.</param>
        bool IsMeetingAllConditions(Todo item);

        /// <summary>
        /// Filter objects based on prepared conditions.
        /// </summary>
        IEnumerable<TObject> Filter();
    }

    public class TodoItemsFilter : IFilter<Todo>
    {
        public IEnumerable<Todo> ItemsToBeFiltered { get; set; }
        public IEnumerable<ICondition<Todo>> Conditions { get; set; }

        public TodoItemsFilter(IEnumerable<Todo> itemsToBeFiltered, IEnumerable<ICondition<Todo>> conditions)
        {
            ItemsToBeFiltered = itemsToBeFiltered;
            Conditions = conditions;
        }

        public IEnumerable<Todo> Filter()
        {
            foreach(var item in ItemsToBeFiltered)
            {
                if(IsMeetingAllConditions(item))
                {
                    yield return item;
                }
            }
        }
        
        public bool IsMeetingAllConditions(Todo item)
        {
            foreach(var condition in Conditions)
            {
                if (!condition.IsSatisfied(item)) return false;
            }
            return true;
        }
    }
}
