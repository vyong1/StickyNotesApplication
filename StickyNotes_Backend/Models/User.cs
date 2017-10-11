using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Models
{
    public class User
    {
        public List<Course> Courses { get; set; }
        public string PreviousFilePath { get; set; }
        private const string UserDataFilePath = @"";

        public User()
        {

        }

        public void SerializeUser()
        {

        }

        public void DeserializeUser()
        {

        }
    }
}
