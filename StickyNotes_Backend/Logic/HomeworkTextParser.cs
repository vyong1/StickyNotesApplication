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
        /// <summary>
        /// The filepath of the homework text file
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filepath"></param>
        public HomeworkTextParser(string filepath)
        {
            FilePath = filepath;
        }

        /// <summary>
        /// Parse the given filepath for a list of courses + assignments
        /// </summary>
        /// <returns></returns>
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
                        //A course has 4 capital letters in a row
                        if (StringUtil.Has4CapitalLettersInARow(line))
                        {
                            allCourses.Add(ParseCourse(line));
                            currentCourse = allCourses.Last();
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

            return allCourses;
        }

        /// <summary>
        /// Parses a course from a line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Course ParseCourse(string line)
        {
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
    }
}
