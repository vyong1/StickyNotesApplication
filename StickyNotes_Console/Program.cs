using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Assignment a = new Assignment("Haha", DateTime.Now);
            Console.WriteLine(a.ToString());

            Console.ReadLine();
        }
    }
}
    