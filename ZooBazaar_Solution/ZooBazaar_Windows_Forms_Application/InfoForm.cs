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

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        public InfoForm(Employee employee) : this()
        {
            Text = "Employee";
        }

        public InfoForm(Animal animal) : this()
        {
            Text = "animal";

        }

        public InfoForm(Habitat habitat) : this()
        {
            Text = "habitat";

        }

        public InfoForm(Zone zone) : this()
        {
            Text = "zone";

        }
    }
}
