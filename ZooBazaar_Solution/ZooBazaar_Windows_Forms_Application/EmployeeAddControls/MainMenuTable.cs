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

namespace ZooBazaar_Windows_Forms_Application.EmployeeAddControls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Fields
        private EmployeeAdd employeeAdd;
        private Label[] labels;
        private TextBox[] textboxes;
        private string[] labelText;

        //Controls
        private AddEmployeeButton btAdd;

        public MainMenuTable(EmployeeAdd employeeAdd)
        {
            this.employeeAdd = employeeAdd;
            //Fields
            labels = new Label[6];
            textboxes = new TextBox[6];
            labelText = new string[] { "FirstName", "LastName", "Email", "Phone", "Address", "Role"};

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
                textboxes[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                textboxes[i].Dock = DockStyle.Fill;
                textboxes[i].Margin = new Padding(0, 0, 0, 1);
            }

            btAdd = new AddEmployeeButton(this);

            //Properties
            Dock = DockStyle.Fill;
            Padding = Padding.Empty;
            Margin = Padding.Empty;
            BackColor = Color.RebeccaPurple;

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

            Controls.Add(textboxes[5], 1, 5);

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
                properties[i].SetValue(employeeAddDTO, textboxes[i].Text);
            }


            //EmployeeAddDTO employeeAddDTO = new EmployeeAddDTO()
            //{
            //    Name = textboxes[0].Text,
            //    Age = (int)numericupdowns[0].Value,
            //    DateOfBirth = new DateTime(),
            //    //Sex = isMale,
            //    Sex = radioButtons[0].Checked,
            //    Species = textboxes[1].Text,
            //    SpeciesType = textboxes[2].Text,
            //    Diet = textboxes[3].Text,
            //    FeedingTimeID = (int)numericupdowns[1].Value,
            //    FeedingInterval = (int)numericupdowns[2].Value,
            //    ZoneID = (int)numericupdowns[3].Value,
            //    HabitatID = (int)numericupdowns[4].Value
            //};

            IEmployeeRepositroty employeeRepositroty = new EmployeeRepository();

            IEmployeeMenager employeeMenager = new EmployeeManager(employeeRepositroty);

            employeeMenager.NewEmployee(employeeAddDTO);

            employeeAdd.Close();
        }
    }
}
