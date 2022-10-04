using System.Drawing.Printing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeActivityTable : TableLayoutPanel
    {
        //Fields
        private string[] employeeButtonsText;

        //Controls
        private EmployeeButton[] _EmployeeButtons;
        public EmployeeActivityTable()
        {

            //Fields
            employeeButtonsText = new string[] { "Add New Employee", "test", "test" };

            //Controls
            _EmployeeButtons = new EmployeeButton[3];

            //Properties
            Dock = DockStyle.Fill;
            //Padding = Padding.Empty;
            //Margin = Padding.Empty;
            ColumnCount = _EmployeeButtons.Length;
            for (int i = 0; i < _EmployeeButtons.Length; i++)
            {
                ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            }


            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));



            //controls -> buttons
            for (int i = employeeButtonsText.Length - 1; i >= 0; i--)
            {
                EmployeeButton employeeButton = new EmployeeButton(i, employeeButtonsText[i], this);
                _EmployeeButtons[i] = employeeButton;
                Controls.Add(employeeButton, i, 0);
            }

            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            //BackColor = Color.Red;
        }
        public void ButtonClick(EmployeeButton buttonClicked)
        {
            EmployeeAdd employeeAdd = new EmployeeAdd();
            employeeAdd.Show();
        }
    }
}