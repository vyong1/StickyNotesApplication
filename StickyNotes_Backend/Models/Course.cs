using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Models
{
    public class Course
    {
        public string Name { get; set; }
        public List<Assignment> Assignments { get; set; }

        public Course()
        {
            Name = "";
            Assignments = new List<Assignment>();
        }

        public Course(string Name, List<Assignment> Assignments)
        {
            this.Name = Name;
            this.Assignments = Assignments;
        }

        public void AddAssignment(Assignment a)
        {
            Assignments.Add(a);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("_");
            sb.Append(Name);
            sb.Append("_");
            return sb.ToString();
        }
    }
}
