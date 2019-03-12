using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibility
{
    public interface ITodoListStorage
    {
        Task Save(TodoList todoList, bool overwrite = false);
    }

    public class TodoListFileStorage : ITodoListStorage
    {
        private const string _path = @"C:\FileStorage\SolidPrinciples\{0}.txt";
        public string FileName { get; private set; }
        public string FilePath { get; private set; }

        public TodoListFileStorage(string fileName)
        {
            FileName = fileName;
            FilePath = String.Format(_path, fileName);
        }

        public async Task Save(TodoList todoList, bool overwrite = false)
        {
            if (overwrite || !File.Exists(FileName))
            {
                await File.WriteAllTextAsync(FilePath, 
                    $"Date: {DateTime.UtcNow.ToString()}\n{todoList.ToString()}");
            }
            else
            {
                using (var writer = new StreamWriter(FilePath, append: true))
                {
                    await writer.WriteLineAsync(
                        $"\n\nDate: {DateTime.UtcNow.ToString()}\n{todoList.ToString()}");
                }
            }
        }
    }
}
