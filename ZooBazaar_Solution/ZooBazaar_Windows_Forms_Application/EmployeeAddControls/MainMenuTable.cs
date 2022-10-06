using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_DomainModels.Models;
using System.ComponentModel.DataAnnotations;

namespace ZooBazaar_Windows_Forms_Application.EmployeeAddControls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        private IEmployeeMenager employeeMenager;
        //Fields
        private EmployeeAdd employeeAdd;
        private Label[] labels;
        private TextBox[] textboxes;
        private ComboBox comboBox;
        private string[] labelText;

        //Controls
        private AddEmployeeButton btAdd;

        public MainMenuTable(EmployeeAdd employeeAdd)
        {
            this.employeeMenager = Program.GetService<IEmployeeMenager>();
            this.employeeAdd = employeeAdd;
            //Fields
            labels = new Label[6];
            textboxes = new TextBox[5];
            labelText = new string[] { "FirstName", "LastName", "Email", "Phone", "Address", "Role"};
            comboBox = new ComboBox();

            //Controls
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Text = labelText[i];
                labels[i].Height = 60;
                labels[i].Dock = DockStyle.Fill;
                labels[i].BackColor = Color.LightGray;
                labels[i].Margin = new Padding(0, 0, 0, 1);
                labels[i].TextAlign = ContentAlignment.MiddleLeft;
            }

            for (int i = 0; i < textboxes.Length; i++)
            {
                textboxes[i] = new TextBox();
                //textboxes[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                textboxes[i].Dock = DockStyle.Fill;
                textboxes[i].Margin = new Padding(0, 0, 0, 1);
            }

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox.Font = new Font("Calibri", 21, FontStyle.Regular);
            comboBox.Dock = DockStyle.Fill;
            comboBox.Margin = new Padding(0, 0, 0, 1);
            comboBox.DataSource = Enum.GetValues(typeof(ROLE));

            comboBox.SelectedItem = ROLE.Caretaker;

            btAdd = new AddEmployeeButton(this);

            //Properties
            Dock = DockStyle.Fill;
            Padding = Padding.Empty;
            Margin = Padding.Empty;
            //BackColor = Color.RebeccaPurple;

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = labels.Length+1;
            for (int i = 0; i < RowCount; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            }

            //Adding Controls
            for (int i = 0; i < labels.Length; i++)
            {
                if(i!=5)
                    Controls.Add(textboxes[i], 1, i);
            }

            Controls.Add(comboBox, 1, 5);

            for (int i = 0; i < labels.Length; i++)
            {
                Controls.Add(labels[i], 0, i);
            }
            Controls.Add(btAdd, 0, RowCount-1);
            SetColumnSpan(btAdd, ColumnCount);
        }


        public void ButtonClick()
        {

            EmployeeAddDTO employeeAddDTO = new EmployeeAddDTO();
            PropertyInfo[] properties = typeof(EmployeeAddDTO).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                if (i != 5)
                    properties[i].SetValue(employeeAddDTO, textboxes[i].Text);
            }
            employeeAddDTO.Role = comboBox.SelectedItem.ToString();

            ValidationContext context = new ValidationContext(employeeAddDTO, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(employeeAddDTO, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    MessageBox.Show(result.ErrorMessage);
                    return;
                }
            }

            employeeMenager.NewEmployee(employeeAddDTO);

            employeeAdd.Close();
        }
    }
}
