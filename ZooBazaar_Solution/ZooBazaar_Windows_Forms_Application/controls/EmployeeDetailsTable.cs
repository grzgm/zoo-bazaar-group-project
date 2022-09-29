using System.Drawing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeDetailsTable : TableLayoutPanel
    {
        private Label _employeeName;
        private Label _employeeFunction;
        private Label _employeeWorkZone;
        private Button _employeeMoreInfo;
        public EmployeeDetailsTable(string name, string function, string workZone)
        {
            //assigning controls
            _employeeName = new Label();
            _employeeName.Text = name;
            _employeeName.Dock = DockStyle.Fill;
            _employeeName.BackColor = Color.LightGray;
            _employeeName.Margin = Padding.Empty;

            _employeeFunction = new Label();
            _employeeFunction.Text = function;
            _employeeFunction.Dock = DockStyle.Fill;
            _employeeFunction.BackColor = Color.LightGray;
            _employeeFunction.Margin = Padding.Empty;

            _employeeWorkZone = new Label();
            _employeeWorkZone.Text = workZone;
            _employeeWorkZone.Dock = DockStyle.Fill;
            _employeeWorkZone.BackColor = Color.LightGray;
            _employeeWorkZone.Margin = Padding.Empty;

            _employeeMoreInfo = new Button();
            _employeeMoreInfo.Text = "...";
            _employeeMoreInfo.Dock = DockStyle.Fill;
            _employeeMoreInfo.Height = 50;
            _employeeMoreInfo.BackColor = Color.Green;
            _employeeMoreInfo.FlatStyle = FlatStyle.Flat;
            _employeeMoreInfo.FlatAppearance.BorderSize = 0;
            _employeeMoreInfo.TextAlign = ContentAlignment.MiddleCenter;
            _employeeMoreInfo.Font = new Font("Calibri", 14, FontStyle.Bold);
            _employeeMoreInfo.Margin = Padding.Empty;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


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
}