using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_Windows_Forms_Application.AnimalAddControls;
using ZooBazaar_Windows_Forms_Application.controls;

namespace ZooBazaar_Windows_Forms_Application
{
    public partial class AnimalAdd : Form
    {
        private AnimalAddControls.MainMenuTable mainMenutable;
        private AnimalTable animalTable;


        public AnimalAdd(AnimalTable animalTable)
        {
            this.animalTable = animalTable;
            InitializeComponent();
            mainMenutable = new AnimalAddControls.MainMenuTable(this);
            Text = "AnimalAdd";
            Size = new Size(650, 780);
        }

        private void EmployeeAdd_Load(object sender, EventArgs e)
        {
            Controls.Add(mainMenutable);
        }

        private void AnimalAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.animalTable.UpdateTableContent();
        }
    }
}
