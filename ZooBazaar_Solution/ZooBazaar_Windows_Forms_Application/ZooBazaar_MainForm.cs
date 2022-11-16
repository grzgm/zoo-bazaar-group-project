using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;



namespace ZooBazaar_Windows_Forms_Application
{
    public partial class ZooBazaar_MainForm : Form
    {
        private MainMenuTable mainMenuTable;
        public ZooBazaar_MainForm()
        {
            InitializeComponent();
            mainMenuTable = new MainMenuTable();
            Size = new Size(1920, 1080);
            WindowState = FormWindowState.Maximized;
        }

        private void ZooBazaar_MainForm_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenuTable);
        }
    }
}
