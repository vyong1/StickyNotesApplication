using StickyNoteApplication.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Models
{
    public class Assignment
    {
        public DateTime DueDate { get; set; }
        public string AssignmentName { get; set; }

        public Assignment()
        {
            this.DueDate = DateTime.Now;
            this.AssignmentName = "";
        }

        public Assignment(string AssignmentName, DateTime DueDate)
        {
            this.DueDate = DueDate;
            this.AssignmentName = AssignmentName;
        }

        public Assignment(string AssignmentName, int DaysUntilDue)
        {
            //Assume that it is due at midnight
            DateTime date = DateTime.Now.AddDays(DaysUntilDue);
            DueDate = DateUtil.GetMidnight(date);

            this.AssignmentName = AssignmentName;
        }

        /// <summary>
        /// Formats the assignment into a readable string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AssignmentName);
            sb.Append(" (");
            sb.Append(DueDate.ToString("MMM"));
            sb.Append(" ");
            sb.Append(DueDate.Day.ToString());
            //TODO: append the time the assignment is due
            sb.Append(")");
            return sb.ToString();
        }


    }
}
