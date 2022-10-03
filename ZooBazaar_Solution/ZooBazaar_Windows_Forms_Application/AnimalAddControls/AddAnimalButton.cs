using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ZooBazaar_Windows_Forms_Application.AnimalAddControls
{
    public class AddAnimalButton : Button
    {
        private MainMenuTable mainMenuTable;

        public AddAnimalButton(MainMenuTable mainMenuTable)
        {
            //fields
            this.mainMenuTable = mainMenuTable;

            //properties
            Dock = DockStyle.Top;
            Height = 120;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = "Add New Animal";
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);
            BackColor = Color.White;


            //events
            this.Click += new System.EventHandler(this.AddButton_Click);
        }

        private void AddButton_Click(object? sender, EventArgs e)
        {
            mainMenuTable.ButtonClick();
        }
    }
}
