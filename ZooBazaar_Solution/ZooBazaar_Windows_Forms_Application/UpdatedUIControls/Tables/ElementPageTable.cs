using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables
{
    internal class ElementPageTable : TableLayoutPanel
    {
        public ElementPageTable()
        {
            Dock = DockStyle.Fill;

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = 19;
            for (int i = 0; i < RowCount; i++)
            {
                if(i % 2 == 0)
                {
                    RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                }
                else
                {
                    RowStyles.Add(new RowStyle(SizeType.Absolute, 2));
                }
            }

            //event
            this.CellPaint += TableLayoutPanel_CellPaint;
        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush;
            if (e.Row % 2 != 0)
            {
                brush = new SolidBrush(ThemeColors.secondaryColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else
            {
                brush = new SolidBrush(Color.Transparent);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
}
