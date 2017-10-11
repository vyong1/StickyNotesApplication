using Microsoft.Win32;
using StickyNoteApplication.Logic;
using StickyNoteApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickyNotes_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DebugLogger DLogger = new DebugLogger();

        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            FontLabel.Content = NoteContents.FontSize;
            DLogger.Log(User.Instance.IsInstalled().ToString());
            if(!User.Instance.IsInstalled())
            {
                User.Instance.Install();
            }

            User.Instance.Deserialize();
            FlowDocumentBuilder fdb = new FlowDocumentBuilder();

            //AddDummyCourses(); //TODO: Delete this

            NoteContents.Document = fdb.BuildDocument(User.Instance.Courses);
        }
        
        private void AddDummyCourses()
        {
            User.Instance.Courses.Add(new Course("CPEG 250", new List<Assignment>() {
                new Assignment("haha", DateTime.Now),
                new Assignment("Jimbo XVII", DateTime.Now)
            }));

            User.Instance.Courses.Add(new Course("HAHA 101", new List<Assignment>() {
                new Assignment("Aeschluss", DateTime.Now),
            }));
        }

        #region Click Handlers

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            User.Instance.Serialize();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Filter = "XML Files|*.xml";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (ofd.ShowDialog() == true)
            {
                string filepath = ofd.FileName;
                DLogger.Log("File opened: " + filepath);

                //Build the document
                FlowDocumentBuilder fdb = new FlowDocumentBuilder();
                FlowDocument doc = fdb.BuildDocument(filepath);

                //Set the text
                NoteContents.Document = doc;
            }
            else
            {

            }
        }

        private void FontUp_Click(object sender, RoutedEventArgs e)
        {
            ChangeFontSize(+1);
        }

        private void FontDown_Click(object sender, RoutedEventArgs e)
        {
            ChangeFontSize(-1);
        }

        #endregion

        #region helpers

        private void ChangeFontSize(int delta)
        {
            NoteContents.FontSize += delta;

            //Update the font label
            FontLabel.Content = NoteContents.FontSize.ToString();
        }

        #endregion


    }

    #region FlowDocumentBuilder


    /// <summary>
    /// Builds a flow document (a rich-text document)
    /// </summary>
    public class FlowDocumentBuilder
    {
        HomeworkXmlSerializer HWXSerializer { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="HomeworkFilepath"></param>
        public FlowDocumentBuilder()
        {
            HWXSerializer = new HomeworkXmlSerializer();
        }

        /// <summary>
        /// Builds the RTF document based off the list of courses and assignments
        /// </summary>
        /// <returns></returns>
        public FlowDocument BuildDocument(string filepath)
        {
            FlowDocument doc = new FlowDocument();
            IEnumerable<Course> allcourses = HWXSerializer.Deserialize(filepath);
            foreach (Course course in allcourses)
            {
                doc.Blocks.Add(new Paragraph(new Bold(new Run(course.Name))) { Margin = new Thickness(0) });

                List lst = new List();
                lst.Margin = new Thickness(0);
                lst.MarkerOffset = 5;
                lst.MarkerStyle = TextMarkerStyle.Circle;
                foreach (Assignment assignment in course.Assignments)
                {
                    lst.ListItems.Add(new ListItem(new Paragraph(new Run(assignment.ToString()))));
                }

                doc.Blocks.Add(lst);

                //Add a "newline"
                doc.Blocks.Add(new Paragraph() { Margin = new Thickness(0) });
            }

            return doc;
        }

        /// <summary>
        /// Builds the RTF document based off the list of courses and assignments
        /// </summary>
        /// <returns></returns>
        public FlowDocument BuildDocument(List<Course> courses)
        {
            FlowDocument doc = new FlowDocument();

            foreach (Course course in courses)
            {
                doc.Blocks.Add(new Paragraph(new Bold(new Run(course.Name))) { Margin = new Thickness(0) });

                List lst = new List();
                lst.Margin = new Thickness(0);
                lst.MarkerOffset = 5;
                lst.MarkerStyle = TextMarkerStyle.Circle;
                foreach (Assignment assignment in course.Assignments)
                {
                    lst.ListItems.Add(new ListItem(new Paragraph(new Run(assignment.ToString()))));
                }

                doc.Blocks.Add(lst);

                //Add a "newline"
                doc.Blocks.Add(new Paragraph() { Margin = new Thickness(0) });
            }

            return doc;
        }
    }

    #endregion

}
