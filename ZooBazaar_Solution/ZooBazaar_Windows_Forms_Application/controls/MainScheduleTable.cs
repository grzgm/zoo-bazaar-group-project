using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainScheduleTable : TableLayoutPanel
    {
        //controls
        private NavBarTable _NavBarTable;
        private Label _WeekLabel;
        private ScheduleTable _ScheduleTable;
        private ActivityTable _ActivityTable;
        



        public MainScheduleTable()
        {
            //controls
            _NavBarTable = new NavBarTable();
            _WeekLabel = new Label();
            _ScheduleTable = new ScheduleTable();
            _ActivityTable = new ActivityTable();



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Controls.Add(_NavBarTable, 0, 0);
            Controls.Add(_ScheduleTable, 0, 2);
            /*debug
            Panel testpanel = new Panel();
            testpanel.Dock = DockStyle.Fill;
            testpanel.BackColor = Color.Red;
            testpanel.Margin = Padding.Empty;
            Controls.Add(testpanel, 0, 2);
            */
        }
    }
}
