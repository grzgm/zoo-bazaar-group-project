using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MenuButton : Button
    {
        private int id;
        private MainMenuTable mainMenuTable;

        public MenuButton(int id, string t, MainMenuTable mainMenuTable)
        {
            //fields
            this.id = id;
            this.mainMenuTable = mainMenuTable;

            //properties
            Dock = DockStyle.Top;
            Height = 120;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = t.ToUpper();
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);


            //events
            this.Click += new System.EventHandler(this.MenuButton_Click);
        }

        private void MenuButton_Click(object? sender, EventArgs e)
        {
            mainMenuTable.ButtonClick(this);
        }
    }
}
