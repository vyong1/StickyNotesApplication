using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StickyNoteApplication.Logic
{
    public class HomeworkXmlSerializer
    {
        public HomeworkXmlSerializer()
        {

        }

        public IEnumerable<Course> Deserialize(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Course>));
            FileStream readStream = new FileStream(path, FileMode.Open);
            List<Course> courses;
            courses = deserializer.Deserialize(readStream) as List<Course>;
            readStream.Close();

            return courses;
        }
    }
}
