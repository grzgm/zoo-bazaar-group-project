using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Controls

        //Color
        SolidBrush highlightBrush;

        public MainMenuTable()
        {
            //Controls


            //Properties
            Dock = DockStyle.Fill;
            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));


            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));



            //Colors
            highlightBrush = new SolidBrush(Color.Green);

            //Events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 && e.Column == 2)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }


            if (e.Column == 1)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }
        }

    }
}
