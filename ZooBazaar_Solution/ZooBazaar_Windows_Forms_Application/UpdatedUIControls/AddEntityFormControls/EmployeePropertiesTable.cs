using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.AddEntityControls
{
    internal class EmployeePropertiesTable : TableLayoutPanel
    {
        private IEmployeeMenager employeeMenager;
        //Fields
        private AddForm employeeAdd; 
        private Label[] labels;
        private TextBox[] textboxes;
        private ComboBox comboBox;
        private string[] labelText;

        //Controls
        private CancelButton cancelButton;
        private ConfirmButton confirmButton;
        public EmployeePropertiesTable(AddForm addForm)
        {
            this.employeeMenager = Program.GetService<IEmployeeMenager>();
            this.employeeAdd = addForm;
            //Fields
            labels = new Label[6];
            textboxes = new TextBox[5];
            labelText = new string[] { "First name", "Last name", "Email", "Phone", "Address", "Role" };
            comboBox = new ComboBox();

            //Controls
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Text = labelText[i];
                labels[i].Height = 60;
                labels[i].Dock = DockStyle.Fill;
                labels[i].BackColor = ThemeColors.dimmedHighlightColor;
                labels[i].Font = new Font("Calibri", 16, FontStyle.Regular);

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

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.Font = new Font("Calibri", 21, FontStyle.Regular);
            comboBox.Dock = DockStyle.Fill;
            comboBox.Margin = new Padding(0, 0, 0, 1);
            comboBox.DataSource = Enum.GetValues(typeof(ROLE));

            comboBox.SelectedItem = ROLE.Caretaker;

            cancelButton = new CancelButton(this);
            confirmButton = new ConfirmButton(this);
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Margin = new Padding(25);
            buttonPanel.Controls.Add(confirmButton);
            buttonPanel.Controls.Add(cancelButton);


            //Properties
            Dock = DockStyle.Fill;
            Padding = Padding.Empty;
            Margin = Padding.Empty;

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            //setting rowcount and styles
            RowCount = labels.Length + 3;
            for (int i = 0; i < RowCount - 3; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            }
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 150));

            //Adding Controls
            for (int i = 0; i < labels.Length; i++)
            {
                Controls.Add(labels[i], 0, i);
                if (i != 5)
                {
                    Controls.Add(textboxes[i], 1, i);
                }
            }
            Controls.Add(comboBox, 1, 5);


            Controls.Add(buttonPanel, 1, RowCount - 1);
            Controls.Add(cancelButton, 1, RowCount - 1);
            Controls.Add(confirmButton, 1, RowCount - 1);

            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
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
        //Closes addform when cancel is clicked
        public void CloseButtonClick()
        {
            employeeAdd.Close();
        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush;
            if (e.Row == RowCount - 2)
            {
                brush = new SolidBrush(ThemeColors.secondaryColor);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            else
            {
                brush = new SolidBrush(Color.Transparent);
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
    }
}
