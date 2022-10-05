using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    public class EmployeeTable : TableLayoutPanel
    {
        
        private List<EmployeeDetailsTable> employeeDetailsTable;

        public EmployeeTable()
        {
            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            //table style
            RowCount = employeeDetailsTable.Count;

            for (int i = 0; i < employeeDetailsTable.Count; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
            }

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            //Filling table with content
            UpdateTableContent();
            UpdateTable();

        }

        //updates Table content
        private void UpdateTable()
        {
            Controls.Clear();
            for (int i = 0; i < employeeDetailsTable.Count - 1; i++)
            {
                Controls.Add(employeeDetailsTable[i], 0, i);
            }
        }

        //refreshes employee List
        public void UpdateTableContent()
        {
            IEmployeeRepositroty employeeRepositroty = new EmployeeRepository();
            IEmployeeMenager employeeMenager = new EmployeeManager(employeeRepositroty);
            List<Employee> Employees = employeeMenager.GetAll();

            employeeDetailsTable = new List<EmployeeDetailsTable>();

            foreach (Employee employee in Employees)
            {
                employeeDetailsTable.Add(new EmployeeDetailsTable(employee, this));
            }
            UpdateTable();
        }
    }
}
