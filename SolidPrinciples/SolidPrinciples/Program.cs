using SolidPrinciples.SingleResponsibility;
using System;

namespace SolidPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Single-Responsibility-Principle

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
            todoListSaver.Save(todoList, true).GetAwaiter().GetResult();


            #endregion
        }
    }
}
