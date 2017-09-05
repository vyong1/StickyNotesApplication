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
                    String line = sr.ReadToEnd();
                    

                    if(IsCourse(line))
                    {
                        allCourses.Add(ParseCourse(line));
                        currentCourse = allCourses.Last();
                    }
                    else
                    {
                        currentCourse.AddAssignment(ParseAssignment(line));
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
            //Strip the '_' from the beginning and end of the line
            line = line.Replace("_", string.Empty);

            return new Course(line, new List<Assignment>());
        }

        private Assignment ParseAssignment(string line)
        {
            line = line.Trim();
            line = line.Replace(">", string.Empty);

            //Parse the assignment name
            int dateStartIndex = line.IndexOf('(');
            string assignmentName = line.Substring(0, dateStartIndex);

            //Parse the due date
            // TODO

            return new Assignment();
        }
    }
}
