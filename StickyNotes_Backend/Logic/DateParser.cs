using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Logic
{
    public class DateParser
    {
        //Gets a midnight datetime
        public static DateTime GetMidnight(DateTime datetime_param)
        {
            return new DateTime(datetime_param.Year, datetime_param.Month, datetime_param.Day, 11, 59, 59);
        }
    }
}
