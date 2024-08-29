using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student() { Name="Guru", PRN=100};
            string str = "C:\\Users\\Group019\\source\\repos\\Serialization\\Serialization\\Serialized.dat";
            using (FileStream fs = new FileStream(str, FileMode.OpenOrCreate, FileAccess.Write))
            {
                new BinaryFormatter().Serialize(fs, s);
                fs.Close();

            }
            using (FileStream fs = new FileStream(str, FileMode.Open, FileAccess.Read))
            {
                Student s1 = new BinaryFormatter().Deserialize(fs) as Student;
                fs.Close();
                Console.WriteLine($"PRN: {s1.PRN} || Name: {s1.Name}");
            }


        }
    }
}
