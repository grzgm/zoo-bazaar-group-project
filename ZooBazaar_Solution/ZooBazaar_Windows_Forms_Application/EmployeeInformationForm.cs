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
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;


namespace ZooBazaar_Windows_Forms_Application
{
    public partial class EmployeeInformationForm : Form
    {

        private StaticInformationTable _StaticInformationTable;

        public EmployeeInformationForm(Employee employee)
        {
            InitializeComponent();
            Size = new Size(1920, 1080);
            Text = null;
            ControlBox = false;
            _StaticInformationTable = new StaticInformationTable(this, employee);
            Controls.Add(_StaticInformationTable);
        }
    }
}
