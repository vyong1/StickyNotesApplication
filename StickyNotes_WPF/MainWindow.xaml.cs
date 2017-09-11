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
            FlowDocument doc = new FlowDocument(
                new Paragraph(new Bold(new Run("Hi")))
                );
            NoteContents.Document = doc;

        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            //TODO Simplify this process

            //Parse the homework
            HomeworkTextParser hwtp = new HomeworkTextParser(@"C:\Users\Viroon Yong\Desktop\TestHomework.txt");
            List<Course> allCoursesAndAssignments = hwtp.Parse();

            //Build the document
            FlowDocumentBuilder fdb = new FlowDocumentBuilder(allCoursesAndAssignments);
            FlowDocument doc = fdb.BuildDocument();

            //Set the text
            NoteContents.Document = doc;
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

    class FlowDocumentBuilder
    {
        public List<Course> Courses { get; set; }

        public FlowDocumentBuilder(List<Course> courses)
        {
            this.Courses = courses;
        }

        public FlowDocument BuildDocument()
        {
            FlowDocument doc = new FlowDocument();
            
            foreach (Course course in Courses)
            {
                doc.Blocks.Add(new Paragraph(new Run(course.Name)) { Margin = new Thickness(0)});


                List lst = new List();
                lst.Margin = new Thickness(0);
                lst.MarkerOffset = 5;
                lst.MarkerStyle = TextMarkerStyle.Circle;

                foreach (Assignment assignment in course.Assignments)
                {
                    lst.ListItems.Add(new ListItem(new Paragraph(new Run(assignment.ToString()))));
                }

                doc.Blocks.Add(lst);
            }

            return doc;
        }
    }

    #endregion

}
