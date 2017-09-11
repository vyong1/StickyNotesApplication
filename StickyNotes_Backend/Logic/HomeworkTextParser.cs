using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Logic
{
    public class HomeworkTextParser
    {
        public string FilePath { get; set; }

        public HomeworkTextParser(string filepath)
        {
            FilePath = filepath;
        }

        public List<Course> Parse()
        {
            List<Course> allCourses = new List<Course>();

            try
            {
                Course currentCourse = null; //The current course being parsed
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    String line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (IsCourse(line))
                        {
                            allCourses.Add(ParseCourse(line));
                            currentCourse = allCourses.Last();
                        }
                        else if (line.Trim() != string.Empty)
                        {
                            currentCourse.AddAssignment(ParseAssignment(line));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }

            return allCourses;
        }

        private bool IsCourse(string line)
        {
            if(line.Substring(0, 1).Equals("_"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Course ParseCourse(string line)
        {
            //A course is formatted for example as _MATH 210
            line = line.Replace("_", string.Empty);
            line = line.Trim();

            return new Course(line, new List<Assignment>());
        }

        private Assignment ParseAssignment(string line)
        {
            //An assignment is formatted for example as >Assignment (Sep 10)
            line = line.Replace(">", string.Empty);
            line = line.Trim();

            //Parse the assignment name
            int dateStartIndex = line.IndexOf('(');
            string assignmentName = line.Substring(0, dateStartIndex);
            
            //Parse the due date
            //string dateString = line.Substring(dateStartIndex, line.Length - 2);
            // TODO

            return new Assignment(assignmentName, DateTime.Now);
        }
    }
}
