using static System.Net.Mime.MediaTypeNames;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeButton : Button
    {
        private int id;
        private EmployeeActivityTable employeeActivityTable;

        public EmployeeButton(int id, string t, EmployeeActivityTable employeeActivityTable)
        {
            //fields
            this.id = id;
            this.employeeActivityTable = employeeActivityTable;

            //properties
            Dock = DockStyle.Top;
            Height = 120;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = t.ToUpper();
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);
            BackColor = Color.White;


            //events
            this.Click += new System.EventHandler(this.EmployeeButton_Click);
        }


        private void EmployeeButton_Click(object? sender, EventArgs e)
        {
            employeeActivityTable.ButtonClick(this);
        }
    }
}