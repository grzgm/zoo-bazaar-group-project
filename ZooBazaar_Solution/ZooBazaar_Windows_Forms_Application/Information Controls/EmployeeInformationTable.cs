using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;


namespace ZooBazaar_Windows_Forms_Application.Information_Controls
{
    public class EmployeeInformationTable : TableLayoutPanel
    {
        private string[] labelStrings;
        private string[] employeeStrings;

        private bool EditMode;


        private TextBox[] EditTextBoxes;

        public EmployeeInformationTable(Employee employee)
        {

            //variables
            labelStrings = new string[7] { "ID", "First name", "Last name", "Email", "Phone", "Adress", "Role" };
            employeeStrings = new string[7] {employee.ID.ToString(),employee.FirstName, employee.LastName, employee.Email, employee.Phone, employee.Address, employee.Role.ToString()};
            EditMode = true;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            Padding = new Padding(10);

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            RowCount = 17;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

            //controls
            EditTextBoxes = new TextBox[6];

            //creates lables for the 1st column
            int y = 0;
            for (int i = 0; i < labelStrings.Length; i++)
            {
                Label informationLabel = new Label();
                informationLabel.Text = labelStrings[i];
                informationLabel.Dock = DockStyle.Fill;
                informationLabel.Margin = Padding.Empty;
                informationLabel.BackColor = ThemeColors.secondaryColor;
                informationLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
                informationLabel.TextAlign = ContentAlignment.MiddleLeft;

                Controls.Add(informationLabel,0,y);
                y += 2;
            }

            UpdateControls();

            //Adding buttons
            Panel panel = new Panel();
            panel.Dock = DockStyle.Top;
            panel.Padding = new Padding(0,5,0,5);
            panel.Height = 100;

            Button FireButton = new Button();
            FireButton.Dock = DockStyle.Right;
            FireButton.Height = 100;
            FireButton.Width = 200;
            FireButton.Margin = new Padding(5);
            FireButton.Text = "Fire";
            FireButton.FlatStyle = FlatStyle.Flat;
            FireButton.FlatAppearance.BorderSize = 0;
            FireButton.BackColor = ThemeColors.secondaryColor;

            EditButton EditButton = new EditButton(this);
            
            panel.Controls.Add(EditButton);
            panel.Controls.Add(FireButton);
            Controls.Add(panel,1,16);

            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }

        public void UpdateControls()
        {
            EditMode = !EditMode;
            int y = 0;
            //Add ID Label
            Label employeeIDLabel = new Label();
            employeeIDLabel.Text = employeeStrings[0];
            employeeIDLabel.Dock = DockStyle.Fill;
            employeeIDLabel.Margin = Padding.Empty;
            employeeIDLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
            employeeIDLabel.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(employeeIDLabel, 1, y);

            y = 2;

            //Removes current controls showed
            for (int i = 1; i < 15; i++)
            {
                Controls.Remove(GetControlFromPosition(1, i));
            }

            if (EditMode)
            {
                for (int i = 1; i < labelStrings.Length; i++)
                {
                    TextBox employeeInformationTextBox = new TextBox();
                    EditTextBoxes[i - 1] = employeeInformationTextBox;
                    employeeInformationTextBox.Text = employeeStrings[i];
                    employeeInformationTextBox.Dock = DockStyle.Fill;
                    employeeInformationTextBox.Margin = new Padding(0,15,0, 15);
                    employeeInformationTextBox.Font = new Font("Calibri", 12, FontStyle.Regular);

                    Controls.Add(employeeInformationTextBox, 1, y);
                    y += 2;
                }
            }
            else
            {
                for (int i = 1; i < labelStrings.Length; i++)
                {
                    Label employeeInformationLabel = new Label();
                    employeeInformationLabel.Text = employeeStrings[i];
                    employeeInformationLabel.Dock = DockStyle.Fill;
                    employeeInformationLabel.Margin = Padding.Empty;
                    employeeInformationLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
                    employeeInformationLabel.TextAlign = ContentAlignment.MiddleLeft;

                    Controls.Add(employeeInformationLabel, 1, y);
                    y += 2;
                }
            }
        }
        public void EditEmployee()
        {
            for (int i = 1; i < employeeStrings.Length; i++)
            {
                employeeStrings[i] = EditTextBoxes[i - 1].Text;
            }

            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.Id = Int32.Parse(employeeStrings[0]);
            employeeDTO.FirstName = employeeStrings[1];
            employeeDTO.LastName = employeeStrings[2];
            employeeDTO.Email = employeeStrings[3];
            employeeDTO.Phone = employeeStrings[4];
            employeeDTO.Address = employeeStrings[5];
            employeeDTO.Role = employeeStrings[6];


            IEmployeeRepositroty employeeRepositroty = new EmployeeRepository();
            IEmployeeMenager employeeMenager = new EmployeeManager(employeeRepositroty);
            employeeMenager.UpdateEmployee(employeeDTO);


        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(ThemeColors.secondaryColor);
            if (e.Row % 2 != 0 && e.Row <= 15)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }

    public class EditButton : Button
    {

        private EmployeeInformationTable parentTable;
        private bool EditMode;
        public EditButton(EmployeeInformationTable employeeInformationTable)
        {
            parentTable = employeeInformationTable;

            EditMode = false;

            Dock = DockStyle.Right;
            Height = 100;
            Width = 200;
            Margin = new Padding(5);
            Text = "Edit";
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ThemeColors.secondaryColor;

            this.Click += new System.EventHandler(EditButton_Click);
        }

        private void EditButton_Click(object? sender, EventArgs e)
        {
            UpdateButton();
            parentTable.UpdateControls();
            this.Click -= new System.EventHandler(EditButton_Click);


        }

        private void EditButton_Save_Click(object? sender, EventArgs e)
        {

            parentTable.EditEmployee();
            parentTable.UpdateControls();
            this.Click -= new System.EventHandler(EditButton_Save_Click);
            UpdateButton();


        }

        private void UpdateButton()
        {
            EditMode = !EditMode;
            if (EditMode)
            {
                Text = "Save";
                this.Click += new System.EventHandler(EditButton_Save_Click);
            }
            else
            {
                Text = "Edit";
                this.Click += new System.EventHandler(EditButton_Click);

            }
        }
    }
}
