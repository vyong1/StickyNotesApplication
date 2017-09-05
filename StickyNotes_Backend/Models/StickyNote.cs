using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes_Backend.Models
{
    public class StickyNote
    {
        public string Text { get; set; }
        public string FilePath { get; set; }
        public int FontSize { get; set; }
        // TODO: Color

        #region ctor

        public StickyNote(string text = "", string filepath = @"/Files/Default.txt", int fontsize = 14)
        {
            this.Text = text;
            this.FilePath = filepath;
            this.FontSize = fontsize;
        }

        #endregion

        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}
