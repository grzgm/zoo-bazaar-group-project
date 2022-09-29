using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class TimeTable : TableLayoutPanel
    {
        public TimeTable()
        {
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            RowCount = 25;
            for (int i = 0; i < RowCount; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Percent, 100 / 25));

                if (i < RowCount - 1)
                {
                    Label timeLabel = new Label();
                    timeLabel.Dock = DockStyle.Fill;
                    timeLabel.BackColor = Color.LightBlue;
                    timeLabel.Text = String.Format("{0}:00 - {1}:00", i, i + 1);
                    timeLabel.TextAlign = ContentAlignment.MiddleRight;
                    Controls.Add(timeLabel, 0, i);
                }
                else
                {
                    /*debug
                    Panel testpanel = new Panel();
                    testpanel.Dock = DockStyle.Fill;
                    testpanel.BackColor = Color.Red;
                    Controls.Add(testpanel, 0, i);
                    //end debug*/
                }
            }
            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        }
    }
}
