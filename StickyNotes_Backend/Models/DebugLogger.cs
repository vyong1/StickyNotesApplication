using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Models
{
    public class DebugLogger
    {
        public string OutputPath { get; set; }

        public DebugLogger(LogMode mode)
        {
            //TODO: Make this more robust
            OutputPath = @"C:/Users/Viroon Yong/source/repos/StickyNotesApplication/StickyNotes_Backend/Files/DebugLog.txt";

            switch (mode)
            {
                case LogMode.AppendToOld:
                    Log("\n");
                    Log("===== " + "Logged at time: " + DateTime.Now);
                    Log("\n");
                    break;
                case LogMode.NewSession:
                    ClearLog();
                    break;
            }
            
        }

        public void Log(string message)
        {
            using (StreamWriter file = new StreamWriter(OutputPath, true))
            {
                file.WriteLine(message);
            }
        }

        public void ClearLog()
        {
            using (StreamWriter file = new StreamWriter(OutputPath))
            {
                file.WriteLine(string.Empty);
            }
        }
    }

    public enum LogMode
    {
        NewSession,
        AppendToOld
    }

}
