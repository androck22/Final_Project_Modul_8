using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\Task2");

            Console.WriteLine($"Исходный размер папки { dirInfo.Name}:" + $"\t{ DirectoryExtension.DirSize(dirInfo)} байт.");
  
            try
            {
                Console.WriteLine($"Освобождено:\t\t\t{ DirectoryExtension.DirSize(dirInfo)} байт.");

                foreach (string folder in Directory.GetDirectories(@"C:\Users\Lenovo\Desktop\Task2"))
                {
                    Directory.Delete(folder, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Текущий размер папки { dirInfo.Name}:" + $"\t{ DirectoryExtension.DirSize(dirInfo)} байт.");

            Console.ReadKey();
        }
    }
}
