using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace StickyNoteApplication.Logic
{
    public class HomeworkXmlSerializer
    {
        public HomeworkXmlSerializer()
        {

        }

        public void Serialize(List<Course> courses, string path)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Deserialize(string path)
        {
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Course>));
                FileStream readStream = new FileStream(path, FileMode.Open);
                List<Course> courses;
                courses = deserializer.Deserialize(readStream) as List<Course>;
                readStream.Close();
                return courses;
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to read the file", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

                DebugLogger logger = new DebugLogger();
                logger.Log("Exception in HomeworkXmlSerializer.Deserialize");
                logger.Log(e.ToString());
            }
            return new List<Course>();
        }
    }
}
