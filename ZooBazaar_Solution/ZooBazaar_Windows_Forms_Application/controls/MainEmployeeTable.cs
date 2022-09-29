using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainEmployeeTable : TableLayoutPanel
    {
        //controls
        private employeeNavBarTable _NavBarTable;
        private employeeTable _ScheduleTable;
        private emptyTable empty;




        public MainEmployeeTable()
        {
            //controls
            _NavBarTable = new employeeNavBarTable();
            _ScheduleTable = new employeeTable();
            empty = new emptyTable();



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 300));

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Controls.Add(_NavBarTable, 0, 0);
            Controls.Add(_ScheduleTable, 0, 2);
            Controls.Add(empty, 0, 3);
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