using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;

namespace ZooBazaar_Windows_Forms_Application.Information_Controls
{
    internal class CloseButton : Button
    {
        private EmployeeInformationForm employeeInformationForm;
        public CloseButton(EmployeeInformationForm parent)
        {
            employeeInformationForm = parent;

            Dock = DockStyle.Top;
            Margin = Padding.Empty;
            Text = "X";
            Height = 100;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ThemeColors.primaryColor;


            //events
            this.Click += new System.EventHandler(CloseButton_Click);
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            employeeInformationForm.Close();
        }
    }
}
