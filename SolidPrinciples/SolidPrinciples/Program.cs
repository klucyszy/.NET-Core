using SolidPrinciples.OpenClosed;
using SolidPrinciples.SingleResponsibility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Single-Responsibility-Principle
            /// TodoList class is only responsible for managing to do items.
            /// TodoListFileStorage class has been created. Saving to do items to file is done
            ///                     on TodoListFileStorage class.
            /// TodoList should be only responsible for managing todo items.

            var todoList = new TodoList();
            var todoListSaver = new TodoListFileStorage("save");
            todoList.Add(new Todo(Category.Hobby, Priority.Low, "learn C#"));
            todoList.Add(new Todo(Category.Work, Priority.Low, "learn Azure Functions"));
            todoList.Add(new Todo(Category.Hobby, Priority.Major, "learn .NET Core"));
            todoList.Add(new Todo(Category.Hobby, Priority.Low, "learn IoT"));

            Console.WriteLine(todoList.ToString());
            todoListSaver.Save(todoList, false).GetAwaiter().GetResult();

            todoList.Add(new Todo(Category.Home, Priority.Major, "tidy bedroom"));
            todoList.Add(new Todo(Category.Home, Priority.Major, "tidy kichen"));

            Console.WriteLine(todoList.ToString());
            // not todoList.SaveToFile(...);
            todoListSaver.Save(todoList, true).GetAwaiter().GetResult();
            #endregion

            #region Open-Closed-Principle
            /// 'Open closed principle states that classes should be open for extension'
            /// The class should be open for extensions, but shouldn't be modified itself.
            /// In this example I've created ICondition<> and IFilter<>
            /// ICondition<> enable us to check is object met our conditions (IsSatisfied method)
            /// IFilter<> enable filtering based on conditions (Filter method)

            //Create conditions which we want to be met.
            var categoryCondition = new CategoryCondition(category: Category.Home);
            var priorityCondition = new PriorityCondition(priority: Priority.Major);

            //Create filters to use created conditions.
            var categoryFilter = 
                new TodoItemsFilter(todoList.Todos, new List<ICondition<Todo>> { categoryCondition });
            var priorityFilter =
                new TodoItemsFilter(todoList.Todos, new List<ICondition<Todo>> { priorityCondition });
            var categoryAndPriorityFilter =
                new TodoItemsFilter(todoList.Todos, new List<ICondition<Todo>> { priorityCondition, categoryCondition });

            //Check results.
            var homeCategoryItems = categoryFilter.Filter().ToList();
            var majorPriorityItems = priorityFilter.Filter().ToList();
            var homeAndMajorItems = categoryAndPriorityFilter.Filter().ToList();

            #endregion
        }
    }
}
