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
        private EmployeeNavBarTable _EmployeeNavBarTable;
        private EmployeeTable _EmployeeTable;
        private EmployeeActivityTable _ActivityTable;




        public MainEmployeeTable()
        {
            //controls
            
            _EmployeeTable = new EmployeeTable();
            _ActivityTable = new EmployeeActivityTable(_EmployeeTable);
            _EmployeeNavBarTable = new EmployeeNavBarTable(_EmployeeTable);
            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Controls.Add(_EmployeeNavBarTable, 0, 0);
            Controls.Add(_EmployeeTable, 0, 1);
            Controls.Add(_ActivityTable, 0, 2);
        }
    }
}