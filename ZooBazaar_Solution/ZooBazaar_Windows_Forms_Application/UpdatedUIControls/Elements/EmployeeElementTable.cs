using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Elements
{
    internal class EmployeeElementTable : TableLayoutPanel
    {

        private Label _employeeName;
        private Label _employeeFunction;
        private Label _employeeWorkZone;
        private List<Label> _labels;
        private InfoButton _employeeMoreInfo;

        public EmployeeElementTable(Employee employee, ElementTable elementTable)
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
                _label.Dock = DockStyle.Fill;
                _label.BackColor = Color.Transparent;
                _label.ForeColor = ThemeColors.foregroundColor;
                _label.Font = new Font("Calibri", 14, FontStyle.Bold);
                _label.Padding = new Padding(5);
                _label.TextAlign = ContentAlignment.MiddleLeft;
            }

            //More info
            //_employeeMoreInfo = new InfoButton(employee, employeeTable);

            //properties
            Dock = DockStyle.Fill;
            Margin = new Padding(5, 0, 5, 5);


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 100));

            ColumnCount = 4;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));

            //Adding controls
            Controls.Add(_employeeName, 0, 0);
            Controls.Add(_employeeFunction, 1, 0);
            Controls.Add(_employeeWorkZone, 2, 0);
            //Controls.Add(_employeeMoreInfo, 3, 0);

            //event
            this.CellPaint += TableLayoutPanel_CellPaint;
        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(ThemeColors.elementColor);
            e.Graphics.FillRectangle(brush, e.CellBounds);
        }
    }
}
