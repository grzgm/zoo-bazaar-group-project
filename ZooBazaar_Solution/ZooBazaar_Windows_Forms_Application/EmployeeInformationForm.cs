using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_Windows_Forms_Application.controls;


namespace ZooBazaar_Windows_Forms_Application
{
    public partial class EmployeeInformationForm : Form
    {

        private StaticInformationTable _StaticInformationTable;

        public EmployeeInformationForm()
        {
            InitializeComponent();
            Size = new Size(1920, 1080);
            Text = null;
            ControlBox = false;
            _StaticInformationTable = new StaticInformationTable(this);
            Controls.Add(_StaticInformationTable);
        }
    }
}
