using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Logic
{
    /// <summary>
    /// Contains misc. procedural methods
    /// </summary>
    public static class DateUtil
    {
        //Gets a midnight datetime
        public static DateTime GetMidnight(DateTime datetime_param)
        {
            return new DateTime(datetime_param.Year, datetime_param.Month, datetime_param.Day, 11, 59, 59);
        }
    }

    public static class StringUtil
    {
        public static bool Has4CapitalLettersInARow(string line)
        {
            int inARow = 0;
            foreach(char c in line)
            {
                if(Char.IsUpper(c))
                {
                    inARow++;
                }
                else
                {
                    inARow = 0;
                }

                if(inARow == 4)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
