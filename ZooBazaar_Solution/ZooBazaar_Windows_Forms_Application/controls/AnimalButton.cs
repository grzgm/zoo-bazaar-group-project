using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalButton : Button
    {
        private int id;
        private AnimalActivityTable animalActivityTable;

        public AnimalButton(int id, string t, AnimalActivityTable animalActivityTable)
        {
            //fields
            this.id = id;
            this.animalActivityTable = animalActivityTable;

            //properties
            Dock = DockStyle.Top;
            Height = 120;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Text = t.ToUpper();
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);


            //events
            this.Click += new System.EventHandler(this.AnimalButton_Click);
        }


        private void AnimalButton_Click(object? sender, EventArgs e)
        {
            animalActivityTable.ButtonClick(this);
        }
    }
}
