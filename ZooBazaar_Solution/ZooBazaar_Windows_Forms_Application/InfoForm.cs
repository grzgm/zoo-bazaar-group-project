using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.InfoFormControls;

namespace ZooBazaar_Windows_Forms_Application
{

    public partial class InfoForm : Form
    {
        private StaticInfoTable staticInfoTable;

        public InfoForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            

        }

        public InfoForm(Employee employee) : this()
        {
            Text = "Employee";
            staticInfoTable = new StaticInfoTable(this, employee);
        }

        public InfoForm(Animal animal) : this()
        {
            Text = "animal";
            staticInfoTable = new StaticInfoTable(this, animal);


        }

        public InfoForm(Habitat habitat) : this()
        {
            Text = "habitat";
            staticInfoTable = new StaticInfoTable(this, habitat);


        }

        public InfoForm(Zone zone) : this()
        {
            Text = "zone";
            staticInfoTable = new StaticInfoTable(this, zone);


        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            Controls.Add(staticInfoTable);
        }
    }
}
