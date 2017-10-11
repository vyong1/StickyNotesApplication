﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StickyNoteApplication.Models
{
    /// <summary>
    /// Singleton user class
    /// </summary>
    public class User
    {
        private static User _instance;
        public static User Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new User();
                }
                return _instance;
            }
        }

        public List<Course> Courses { get; set; }

        private static string ProjectDataDirectoryPath = (Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\StickyNotesApplication");
        private static string UserDataPath = (ProjectDataDirectoryPath + @"\UserData.xml");

        private User()
        {
            
        }

        /// <summary>
        /// Serialize this User into UserData.xml
        /// </summary>
        public void SerializeUser()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(User));
            StreamWriter writer = new StreamWriter(UserDataPath, false);
            serializer.Serialize(writer, _instance);
        }

        /// <summary>
        /// Deserialize the UserData.xml into this instance of user
        /// </summary>
        public void DeserializeUser()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(User));
            FileStream readStream = new FileStream(UserDataPath, FileMode.Open);
            _instance = deserializer.Deserialize(readStream) as User;
            readStream.Close();
        }

        /// <summary>
        /// Generates the directories for user data
        /// </summary>
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
            _instance = new User();
        }
    }
}
