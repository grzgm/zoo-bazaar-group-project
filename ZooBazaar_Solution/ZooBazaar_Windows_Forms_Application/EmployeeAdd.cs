using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_Windows_Forms_Application.EmployeeAddControls;
using ZooBazaar_Windows_Forms_Application.controls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class EmployeeAdd : Form
    {
        private EmployeeAddControls.MainMenuTable mainMenutable;
        private EmployeeTable employeeTable;

        public EmployeeAdd(EmployeeTable employeeTable)
        {
            this.employeeTable = employeeTable;
            InitializeComponent();
            mainMenutable = new EmployeeAddControls.MainMenuTable(this);

            Size = new Size(650, (8*60));
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }

        private void EmployeeAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.employeeTable.UpdateTableContent();
        }
    }
}
