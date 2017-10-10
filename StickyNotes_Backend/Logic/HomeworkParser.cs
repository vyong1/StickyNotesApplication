using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Logic
{
    public class HomeworkParser
    {
        /// <summary>
        /// The filepath of the homework text file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// A list of all the courses (which includes a list of all the assignments respective to that course)
        /// </summary>
        public List<Course> AllCourses { get; set; } = new List<Course>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filepath"></param>
        public HomeworkParser(string filepath)
        {
            throw new ObsoleteCodeException();
            //FilePath = filepath;
        }

        /// <summary>
        /// Parse the given filepath for a list of courses + assignments
        /// </summary>
        /// <returns></returns>
        public List<Course> Parse()
        {
            AllCourses.Clear(); //Clear list of courses prior to parsing
            DateParser DateParser = new DateParser();

            try
            {
                Course currentCourse = null; //The current course being parsed
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    String line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        //A course has 4 capital letters in a row
                        if (Has4CapitalLettersInARow(line))
                        {
                            AllCourses.Add(ParseCourse(line));
                            currentCourse = AllCourses.Last();
                        }
                        //Assignment
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

            return AllCourses;
        }

        /// <summary>
        /// Parses a course from a line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Course ParseCourse(string line)
        {
            //TODO Replace this with a more robust system for checking courses

            //A course has 4 capital letters in a row
            line = line.Replace("_", string.Empty);
            line = line.Replace(" ", string.Empty);
            line = line.Trim();

            //Format the course name nicely
            StringBuilder sb = new StringBuilder();
            sb.Append(line.Substring(0, 4));
            sb.Append(" ");
            sb.Append(line.Substring(4));

            return new Course(sb.ToString(), new List<Assignment>());
        }

        /// <summary>
        /// Parses a an assignment from a line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Assignment ParseAssignment(string line)
        {
            //An assignment is formatted for example as >Assignment (Sep 10)
            line = line.Replace(">", string.Empty);
            line = line.Replace("-", string.Empty);
            line = line.Trim();

            //Parse the assignment name
            int dateStartIndex = line.IndexOf('(');
            string assignmentName = line.Substring(0, dateStartIndex);
            
            // TODO Parse the due date

            return new Assignment(assignmentName, DateTime.Now);
        }

        private bool Has4CapitalLettersInARow(string line)
        {
            int inARow = 0;
            foreach (char c in line)
            {
                if (Char.IsUpper(c))
                {
                    inARow++;
                }
                else
                {
                    inARow = 0;
                }

                if (inARow == 4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
