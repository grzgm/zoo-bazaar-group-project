using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeTable : TableLayoutPanel
    {
        private List<EmployeeDetailsTable> employeeDetailsTable;

        public EmployeeTable()
        {
            //assigning variables

            //assigning controls
            employeeDetailsTable = new List<EmployeeDetailsTable>();
            for (int i = 0; i < 5; i++)
            {
                employeeDetailsTable.Add(new EmployeeDetailsTable("Employee", "Employee", "Employee"));
            }



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //table style
            RowCount = employeeDetailsTable.Count;

            for (int i = 0; i < employeeDetailsTable.Count; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            }

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));


            //adding controls

            // -1 cuz last employee is streched ikd why
            for (int i = 0; i < employeeDetailsTable.Count-1; i++)
            {
                Controls.Add(employeeDetailsTable[i], 0, i);
            }

            //debug
            //BackColor = Color.Blue;
        }
    }
}
