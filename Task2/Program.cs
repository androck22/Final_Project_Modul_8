using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\Task2");

            Console.WriteLine($"Имя папки: { dirInfo.Name}" + $"\nРазмер папки: { DirectoryExtension.DirSize(dirInfo)} байт");

            Console.ReadKey();
        }
    }
}
