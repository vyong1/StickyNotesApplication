using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StickyNotes_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Establish the directory
            string name = @"MyAssignments.xml";
            string path = Environment.CurrentDirectory;
            path = System.IO.Path.GetFullPath(System.IO.Path.Combine(path, @"..\..\")); //Move 2 folders up
            path = System.IO.Path.Combine(path, name);

            //Ser(path);
            //DeSer(path);
            


            Console.ReadLine();
        }

        public static void Ser(string path)
        {
            List<Course> courses = new List<Course>();

            courses.Add(new Course("CPEG 250", new List<Assignment>() {
                new Assignment("haha", DateTime.Now),
                new Assignment("Jimbo XVII", DateTime.Now)
            }));

            courses.Add(new Course("HAHA 101", new List<Assignment>() {
                new Assignment("Aeschluss", DateTime.Now),
            }));
            
            //Serialize
            XmlSerializer serializer = new XmlSerializer(typeof(List<Course>));
            StreamWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, courses);
        }

        public static void DeSer(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Course>));
            FileStream readStream = new FileStream(path, FileMode.Open);

            List<Course> courses;
            courses = deserializer.Deserialize(readStream) as List<Course>;
            readStream.Close();

            foreach(Course course in courses)
            {
                Console.WriteLine(course.ToString());
                foreach(Assignment assignment in course.Assignments)
                {
                    Console.WriteLine(assignment.ToString());
                }
            }
        }
    }
}
