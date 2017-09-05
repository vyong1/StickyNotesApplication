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

        public Assignment(string AssignmentName, DateTime DueDate)
        {
            this.DueDate = DueDate;
            this.AssignmentName = AssignmentName;
        }

        public Assignment(string AssignmentName, int DaysUntilDue)
        {
            //Assume that it is due at midnight
            DateTime date = DateTime.Now.AddDays(DaysUntilDue);
            DueDate = GetMidnightDate(date);

            this.AssignmentName = AssignmentName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AssignmentName);
            sb.Append(" ( ");
            sb.Append(DueDate.ToString("MMM"));
            sb.Append(" ");
            sb.Append(DueDate.Day.ToString());
            //TODO: append the time the assignment is due
            sb.Append(" )");
            return sb.ToString();
        }

        //Sets a datetime to midnight
        private DateTime GetMidnightDate(DateTime datetime_param)
        {
            return new DateTime(datetime_param.Year, datetime_param.Month, datetime_param.Day, 11, 59, 59);
        }
    }
}
