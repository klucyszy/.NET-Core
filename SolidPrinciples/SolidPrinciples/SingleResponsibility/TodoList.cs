using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibility
{
    public interface ITodoList
    {
        /// <summary>
        /// Items which should be done.
        /// </summary>
        List<Todo> Todos { get; }
        /// <summary>
        /// Items marked as done.
        /// </summary>
        List<Todo> Dones { get; }

        /// <summary>
        /// Returns all items which should be done. Category can be specified.
        /// </summary>
        /// <param name="category">Category of the th do items.</param>
        List<Todo> GetAll(Category? category = null);
        /// <summary>
        /// Returns all items which are done. Category can be specified.
        /// </summary>
        /// <param name="category">Category of the th do items.</param>
        List<Todo> GetAllDone(Category? category = null);
        /// <summary>
        /// Returns Todo item.
        /// </summary>
        /// <param name="id">Identifier of the todo item.</param>
        /// <param name="isDone">IsDone define if todo item is get from Todos list or from Dones list.</param>
        void Get(int id, bool isDone = false);
        /// <summary>
        /// Adds item to Todos list.
        /// </summary>
        /// <param name="todo">Todo item.</param>
        void Add(Todo todo);
        /// <summary>
        /// Moving item from Todos list to Dones list.
        /// </summary>
        /// <param name="id">Identifier of the done item.</param>
        void MarkAsDone(int id);
        /// <summary>
        /// Removes to do item from Todos list.
        /// </summary>
        /// <param name="category">Identifier of the done item.</param>
        void Remove(int id);

    }

    public class TodoList : ITodoList
    {
        public TodoList()
        {
            Todos = new List<Todo>();
            Dones = new List<Todo>();
        }

        public List<Todo> Todos { get; }

        public List<Todo> Dones { get; }

        public void Add(Todo todo)
        {
            Todos.Add(todo);
        }

        public void Get(int id, bool isDone = false)
        {
            if (isDone)
            {
                Dones.FirstOrDefault(x => x.Id == id);
            }

            Todos.FirstOrDefault(x => x.Id == id);
        }

        public List<Todo> GetAll(Category? category = null)
        {
            if (category.HasValue)
            {
                return Todos
                    .Where(x => x.Category == category.Value)
                    .ToList();
            }

            return Todos;
        }

        public List<Todo> GetAllDone(Category? category = null)
        {
            if (category.HasValue)
            {
                return Dones
                    .Where(x => x.Category == category.Value)
                    .ToList();
            }

            return Dones;
        }

        public void MarkAsDone(int id)
        {
            var todo = Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                throw new KeyNotFoundException();

            Todos.Remove(todo);
            Dones.Add(todo);
        }

        public void Remove(int id)
        {
            var todo = Todos.FirstOrDefault(x => x.Id == id);
            if (todo == null)
                throw new KeyNotFoundException();

            Todos.Remove(todo);
        }

        public override string ToString()
        {
            var result = "----------TO-DO----------\n";
            Todos
                .ForEach(item =>
                result = string.Concat(result, 
                    $"Category: {item.Category.ToString()}, " +
                    $"Description: {item.Description}.\n"));
            result = string.Concat(result, "----------DO-NE----------\n");
            Dones
                .ForEach(item =>
                result = string.Concat(result, 
                    $"Category: {item.Category.ToString()}, " +
                    $"Description: {item.Description}.\n"));
            return result;
        }
    }
}
