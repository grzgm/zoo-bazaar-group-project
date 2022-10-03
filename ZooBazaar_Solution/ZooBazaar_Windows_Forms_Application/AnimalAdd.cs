using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_Windows_Forms_Application.AnimalAddControls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class AnimalAdd : Form
    {
        private MainMenuTable mainMenutable;

        public AnimalAdd()
        {
            InitializeComponent();
            mainMenutable = new MainMenuTable(this);

            Size = new Size(650, 780);
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }
    }
}
