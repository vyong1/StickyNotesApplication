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
        }


        #region Click Handlers

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
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
                FlowDocumentBuilder fdb = new FlowDocumentBuilder(filepath);
                FlowDocument doc = fdb.BuildDocument();

                //Set the text
                NoteContents.Document = doc;
            }
            else
            {
                throw new NotImplementedException();
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
        /// <summary>
        /// Parses a homework file
        /// </summary>
        public HomeworkParser HWParser { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="HomeworkFilepath"></param>
        public FlowDocumentBuilder(string HomeworkFilepath)
        {
            HWParser = new HomeworkParser(HomeworkFilepath);
        }

        /// <summary>
        /// Builds the RTF document based off the list of courses and assignments
        /// </summary>
        /// <returns></returns>
        public FlowDocument BuildDocument()
        {
            FlowDocument doc = new FlowDocument();
            
            foreach (Course course in HWParser.AllCourses)
            {
                doc.Blocks.Add(new Paragraph(new Bold(new Run(course.Name))) { Margin = new Thickness(0)});

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
