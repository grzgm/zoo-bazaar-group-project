using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.Theme;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AddButton : Button
    {

        public AddButton()
        {
            //fields

            //properties
            BackColor = ThemeColors.highlightColor;
            Dock = DockStyle.Right;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            Height = 100;
            Width = 300;
            Margin = new Padding(10);
            Text = "+ Add New";

            //controls

            //events
            this.Click += new System.EventHandler(this.AddButton_Click);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
