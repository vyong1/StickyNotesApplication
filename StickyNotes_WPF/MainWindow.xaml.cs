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
using StickyNotes_Backend.Models;

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
            StickyNote note = new StickyNote();
            NoteContents.Text = "Save";
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            StickyNote note = new StickyNote();
            NoteContents.Text = "Load";
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

}
