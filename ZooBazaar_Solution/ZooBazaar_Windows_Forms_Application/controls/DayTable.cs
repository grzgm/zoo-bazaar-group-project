using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class DayTable : TableLayoutPanel
    {
        private MainScheduleTable mainScheduleTable;

        private int id;

        private BlockButton[] _BlockButton;
        public DayTable(MainScheduleTable mainScheduleTable, int id)
        {
            this.mainScheduleTable = mainScheduleTable;
            this.id = id;

            //assigning controls
            _BlockButton = new BlockButton[24];
            for (int i = 0; i < _BlockButton.Length; i++)
            {
                _BlockButton[i] = new BlockButton(mainScheduleTable, this.id,  i);
            }



            //properties
            Dock = DockStyle.Fill;
            //Margin = Padding.Empty;



            //table style
            RowCount = 25;
            for (int i = 0; i < RowCount; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Percent, 100/25));

                if(i < RowCount - 1)
                {
                    Controls.Add(_BlockButton[i], 0, i);
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
