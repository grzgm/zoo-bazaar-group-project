using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class StaticInformationTable : TableLayoutPanel
    {

        //fields
        private SolidBrush highLightBrush;
        
        //conrols
        private Button closeButton;

        public StaticInformationTable()
        {
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //tble style
            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent));


            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if(e.Column == 0)
            {
                highLightBrush = new SolidBrush(Color.Gray);
                e.Graphics.FillRectangle(highLightBrush, e.CellBounds);
            }
            else if(e.Column == 1)
            {
                highLightBrush = new SolidBrush(Color.Green);
                e.Graphics.FillRectangle(highLightBrush, e.CellBounds);
            }

        }
    }
}
