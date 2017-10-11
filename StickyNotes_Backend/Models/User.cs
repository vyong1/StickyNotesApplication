using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNoteApplication.Models
{
    public class User
    {
        public List<Course> Courses { get; set; }
        public string PreviousFilePath { get; set; }
        private static string ProjectDataDirectoryPath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StickyNotesApplication");
        private static string UserDataPath = (ProjectDataDirectoryPath + @"\UserData.xml");

        public User()
        {
            
        }

        public void SerializeUser()
        {

        }

        public void DeserializeUser()
        {

        }

        public void InstallUser()
        {
            //Make sure the directory exists
            if(!Directory.Exists(ProjectDataDirectoryPath))
            {
                Directory.CreateDirectory(ProjectDataDirectoryPath);
            }

            DirectoryInfo dir = new DirectoryInfo(ProjectDataDirectoryPath);

            //Clean the folder
            foreach (FileInfo file in dir.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                di.Delete(true);
            }

            //Make the new files
            File.Create(UserDataPath);
            SerializeUser();
        }
    }
}
