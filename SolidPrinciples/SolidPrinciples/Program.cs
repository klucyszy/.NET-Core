using SolidPrinciples.SingleResponsibility;
using System;

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
            todoList.Add(new Todo(Category.Hobby, "learn C#"));
            todoList.Add(new Todo(Category.Hobby, "learn Azure Functions"));
            todoList.Add(new Todo(Category.Hobby, "learn .NET Core"));
            todoList.Add(new Todo(Category.Hobby, "learn IoT"));

            Console.WriteLine(todoList.ToString());
            todoListSaver.Save(todoList, false).GetAwaiter().GetResult();

            todoList.Add(new Todo(Category.Home, "tidy bedroom"));
            todoList.Add(new Todo(Category.Home, "tidy kichen"));

            Console.WriteLine(todoList.ToString());
            // not todoList.SaveToFile(...);
            todoListSaver.Save(todoList, true).GetAwaiter().GetResult();


            #endregion
        }
    }
}
