using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Elements;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables
{
    internal class ElementTable : TableLayoutPanel
    {
        
        private IEmployeeMenager _employeeMenager;
        
        
        
        private List<ElementPageTable> pageTables;


        private int entityId;
        private int listCount;
        private List<EmployeeElementTable> employeeElements;
        private List<Employee> employees;


        public ElementTable()
        {
            Dock = DockStyle.Fill;
            AutoScroll = true;
            Padding = new Padding(5);

            RowCount = 3;


        }
        public ElementTable(int entityId) : this()
        {
            this.entityId = entityId;
            switch (this.entityId)
            {
                case 0: //Employee
                    _employeeMenager = Program.GetService<IEmployeeMenager>();
                    UpdateTable_AllEmployees();

                    break;
                case 1: //Animal
                    break;
                case 2: //Habitat
                    break;
                case 3: //Zone
                    break;
                case 4: //Stock
                    break;
            }
        }

        #region General methods

        private void ClearTable()
        {
            Controls.Clear();
        }


        #endregion

        #region Employee related methods
        public void UpdateTable_ShowEmployees()
        {
            ElementPanel[] elementPanels = new ElementPanel[employeeElements.Count];
            Panel[] gap = new Panel[employeeElements.Count];
            for (int i = 0; i < elementPanels.Length; i++)
            {
                elementPanels[i] = new ElementPanel();
                gap[i] = new Panel();
            }

            for (int i = 0; i < employeeElements.Count; i++)
            {
                elementPanels[i].Controls.Add(employeeElements[i]);
                
                Controls.Add(gap[i]);
                Controls.Add(elementPanels[i]);
            }
        }
        public void UpdateTable_AllEmployees()
        {
            ClearTable();
            employees = _employeeMenager.GetAll();
            /*
            Split<Employee>(Employees, 10);

            IEnumerable<Employee[]> chunks = Employees.Chunk(10);
            int count = chunks.Count();
            //CONTINUE HERE */

            employeeElements = new List<EmployeeElementTable>();

            foreach (Employee employee in employees)
            {
                employeeElements.Add(new EmployeeElementTable(employee, this));
            }
            UpdateTable_ShowEmployees();
        }

        public void UpdateTable_EmployeesByRole(ROLE _role)
        {
            ClearTable();

            IEnumerable<Employee> employees = _employeeMenager.GetAll().Where(role => role.Role == _role);

            employeeElements = new List<EmployeeElementTable>();

            foreach (Employee employee in employees)
            {
                employeeElements.Add(new EmployeeElementTable(employee, this));
            }
            UpdateTable_ShowEmployees();
        }

        #endregion

        #region Animal related methods

        #endregion
        #region Habitat related methods

        #endregion

        #region Zone related methods

        #endregion

        #region Stock related methods

        #endregion

    }

}
