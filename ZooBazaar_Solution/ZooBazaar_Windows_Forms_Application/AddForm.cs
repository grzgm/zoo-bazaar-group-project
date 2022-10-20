using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.AddEntityControls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class AddForm : Form
    {

        private StaticAddEntityTable mainAddEntityTable;

        public AddForm(int entityID)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            mainAddEntityTable = new StaticAddEntityTable(entityID, this);
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            Controls.Add(mainAddEntityTable);

        }
    }
}
