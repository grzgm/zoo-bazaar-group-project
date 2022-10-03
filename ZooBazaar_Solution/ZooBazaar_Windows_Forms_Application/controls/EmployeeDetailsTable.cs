using System.Drawing;
using ZooBazaar_Windows_Forms_Application.Theme;


namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeDetailsTable : TableLayoutPanel
    {
        private Label _employeeName;
        private Label _employeeFunction;
        private Label _employeeWorkZone;
        private List<Label> _labels;
        private Button _employeeMoreInfo;
        public EmployeeDetailsTable(string name, string function, string workZone)
        {
            //assigning controls
            _labels = new List<Label>();
            _employeeName = new Label();
            _employeeName.Text = name;
            _labels.Add(_employeeName);

            _employeeFunction = new Label();
            _employeeFunction.Text = function;
            _labels.Add(_employeeFunction);

            _employeeWorkZone = new Label();
            _employeeWorkZone.Text = workZone;
            _labels.Add(_employeeWorkZone);

            foreach (Label _label in _labels)
            {
                _label.Dock = DockStyle.Fill;
                _label.BackColor = Color.LightGray;
                _label.Margin = new Padding(0, 0, 1, 0);
                _label.TextAlign = ContentAlignment.MiddleLeft;
            }

            _employeeMoreInfo = new Button();
            _employeeMoreInfo.Text = "...";
            _employeeMoreInfo.Dock = DockStyle.Fill;
            _employeeMoreInfo.Height = 50;
            _employeeMoreInfo.BackColor = ThemeColors.highlightColor;
            _employeeMoreInfo.FlatStyle = FlatStyle.Flat;
            _employeeMoreInfo.FlatAppearance.BorderSize = 0;
            _employeeMoreInfo.TextAlign = ContentAlignment.MiddleCenter;
            _employeeMoreInfo.Font = new Font("Calibri", 14, FontStyle.Bold);
            _employeeMoreInfo.Margin = Padding.Empty;
            _employeeMoreInfo.TextAlign = ContentAlignment.MiddleCenter;

            //properties
            Dock = DockStyle.Fill;
            //Margin = new Padding(0, 0, 0, 5);


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