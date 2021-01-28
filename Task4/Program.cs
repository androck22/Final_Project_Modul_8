using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FinalTask
{
    class BinaryTest
    {
        public static FileInfo configFile = new FileInfo(@"SystemConfig.txt");
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Lenovo\Desktop\Students\Students.dat";
            var formatter = new BinaryFormatter();
            formatter.Binder = new PreMergeToMergedDeserializationBinder();

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                Student[] deserilizeStudents = (Student[])formatter.Deserialize(fs);

                foreach (Student p in deserilizeStudents)
                {
                    using (StreamWriter sw = configFile.AppendText())
                    {
                        sw.WriteLine($"Name: {p.Name} Group: {p.Group} Birthday: {p.DateOfBirth.ToShortDateString()}");
                    }
                }
            }
        }

        sealed class PreMergeToMergedDeserializationBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type typeToDeserialize = null;

                // For each assemblyName/typeName that you want to deserialize to
                // a different type, set typeToDeserialize to the desired type.
                String exeAssembly = Assembly.GetExecutingAssembly().FullName;

                // The following line of code returns the type.
                typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                    typeName, exeAssembly));

                return typeToDeserialize;
            }
        }
    }

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
