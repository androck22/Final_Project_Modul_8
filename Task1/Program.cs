using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreatFolder();
        }
        static void CreatFolder()
        {
            string path = @"C:\Users\Lenovo\Desktop\NewFolder";
            string subpath = @"fold1";
            string file = @"C:\Users\Lenovo\Desktop\NewFolder\fold1\newFile1.txt";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            FileInfo fileInfo = new FileInfo(file);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                Console.WriteLine("Папка по указанному пути созданна");
            }
            dirInfo.CreateSubdirectory(subpath);
            Console.WriteLine("Субдириктория создана");

            CreatFile();

            RecursiveDelete(dirInfo);
            RecursiveDeleteFiles(fileInfo);
        }
        static void CreatFile()
        {
            string newFile1 = @"C:\Users\Lenovo\Desktop\NewFolder\fold1\newFile1.txt";
            FileInfo fileInfo = new FileInfo(newFile1);
            if (!fileInfo.Exists)
            {
                fileInfo.Create();
                Console.WriteLine("Файл по указанному пути создан");
            }
        }
        static void RecursiveDelete(DirectoryInfo baseDir)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtFileModified = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\NewFolder").LastAccessTime;
            if (dtNow - dtFileModified >= TimeSpan.FromSeconds(10))
            {
                if (!baseDir.Exists)
                    return;

                foreach (var dir in baseDir.EnumerateDirectories())
                {
                    RecursiveDelete(dir);
                }
                baseDir.Delete(true); 
            }
        }
        static void RecursiveDeleteFiles(FileInfo fileInf)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dtFileModified2 = new FileInfo(@"C:\Users\Lenovo\Desktop\NewFolder\fold1\newFile1.txt").LastAccessTime;
            if (dtNow - dtFileModified2 >= TimeSpan.FromSeconds(10))
            {
                if (!fileInf.Exists)
                    return;
                else
                    fileInf.Delete();
            }
        }
    }
}
