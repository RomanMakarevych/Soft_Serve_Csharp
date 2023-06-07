using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Home_Work_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Student student = new Student() { Name = "Adama",LastName ="Traure", Birthdate = new DateTime(1998,10,2),Group = 1 };

            // Json JsonSerializer:

            string json = JsonSerializer.Serialize(student);
            File.WriteAllText("Json data.json", json);

            string jsonRead = File.ReadAllText("Json data.json");
            Student? stdResult = JsonSerializer.Deserialize<Student>(jsonRead);

            Console.WriteLine(stdResult);

            //XML

            XmlSerializer xmlSerializer = new(typeof(Student));
            using (FileStream fs = File.Create("student.xml"))
            {
                xmlSerializer.Serialize(fs, student);
            }
            Student? studentXML = null;
            using (FileStream fs = File.OpenRead("student.xml"))
            {
                studentXML = xmlSerializer.Deserialize(fs) as Student;
            }
            Console.WriteLine(studentXML.ToString());

            // Binary

            BinaryFormatter binary = new();
            using (FileStream fs = File.Create("studentBinary.bin"))
            {
                binary.Serialize(fs, student);
            }

            Student stdBinary = null;
            using (FileStream fs = File.OpenRead("studentBinary.bin"))
            {
                stdBinary = (Student)binary.Deserialize(fs);
            }
            Console.WriteLine(stdBinary.ToString());
        }
    }

    [Serializable]
   public class Student
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public  DateTime Birthdate { get; set; }
        public int Group { get; set; }

        public Student() { }


        public override string ToString()
        {
            return $"Name: {Name}, Last name: {LastName}, Birthdate: {Birthdate.ToShortDateString()}, Group: {Group} ";
        }

    }
   
}