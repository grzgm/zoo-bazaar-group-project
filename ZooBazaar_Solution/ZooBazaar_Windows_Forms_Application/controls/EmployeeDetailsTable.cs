using System.Drawing;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;


namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeDetailsTable : TableLayoutPanel
    {
        private Label _employeeName;
        private Label _employeeFunction;
        private Label _employeeWorkZone;
        private List<Label> _labels;
        private InformationButton _employeeMoreInfo;
        public EmployeeDetailsTable(Employee employee)
        {
            //assigning controls
            _labels = new List<Label>();
            _employeeName = new Label();
            _employeeName.Text = employee.FirstName;
            _labels.Add(_employeeName);

            _employeeFunction = new Label();
            _employeeFunction.Text = employee.LastName;
            _labels.Add(_employeeFunction);

            _employeeWorkZone = new Label();
            _employeeWorkZone.Text = employee.Role.ToString();
            _labels.Add(_employeeWorkZone);

            foreach (Label _label in _labels)
            {
                _label.Height = 50;
                _label.Dock = DockStyle.Fill;
                _label.BackColor = Color.LightGray;
                _label.Margin = new Padding(0, 0, 1, 0);
                _label.TextAlign = ContentAlignment.MiddleLeft;
            }

            //More info
            _employeeMoreInfo = new InformationButton(employee);
            


            //properties
            Dock = DockStyle.Fill;
            Margin = new Padding(5, 0, 5, 5);


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            ColumnCount = 4;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

            //Adding controls
            Controls.Add(_employeeName, 0, 0);
            Controls.Add(_employeeFunction, 1, 0);
            Controls.Add(_employeeWorkZone, 2, 0);
            Controls.Add(_employeeMoreInfo, 3, 0);
        }
    }

    public class InformationButton : Button
    {
        private EmployeeInformationForm employeeForm;
        private Employee currentEmployee;

        public InformationButton(Employee employee)
        {
            
            currentEmployee = employee;

            //properties
            Text = "...";
            Dock = DockStyle.Fill;
            Height = 50;
            BackColor = ThemeColors.highlightColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);
            Margin = Padding.Empty;


            //events
            this.Click += new System.EventHandler(this.InformationButton_Click);


        }

        private void InformationButton_Click(object? sender, EventArgs e)
        {
            employeeForm = new EmployeeInformationForm(currentEmployee);
            employeeForm.Show();
        }
    }
}