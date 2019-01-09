using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace DSW.Core.Utility.Forms
{
    public delegate void FormatCellEventHandler(object sender, DataGridFormatCellEventArgs e);

    public class DataGridFormatCellEventArgs : EventArgs
    {
        public int Row;
        public CurrencyManager Source;
        public Brush BackBrush;
        public Brush ForeBrush;

        public DataGridFormatCellEventArgs(int row, CurrencyManager manager)
        {
            this.Row = row;
            this.Source = manager;
        }
    }
}
