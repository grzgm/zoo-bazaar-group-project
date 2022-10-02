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

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class EmployeeAdd : Form
    {
        private MainMenuTable mainMenutable;

        public EmployeeAdd()
        {
            InitializeComponent();
            mainMenutable = new MainMenuTable();

            Size = new Size(500, 780);
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }
    }
}
