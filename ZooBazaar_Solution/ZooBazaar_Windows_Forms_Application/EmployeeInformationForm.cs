﻿using System;
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
        private EmployeeTable EmployeeTable;

        public EmployeeInformationForm(Employee employee, EmployeeTable employeeTable)
        {
            InitializeComponent();
            Size = new Size(1920, 1080);
            Text = null;
            _StaticInformationTable = new StaticInformationTable(employee, this);
            this.EmployeeTable = employeeTable;
            Controls.Add(_StaticInformationTable);
        }

        private void EmployeeInformationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.EmployeeTable.UpdateTableContent();
        }
    }
}
