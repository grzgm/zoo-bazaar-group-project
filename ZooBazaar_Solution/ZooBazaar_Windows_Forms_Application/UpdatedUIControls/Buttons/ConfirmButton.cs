using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.AddEntityControls;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class ConfirmButton : ActionBaseButton
    {

        private EmployeePropertiesTable employeePropertiesTable;
        private AnimalPropertiesTable animalPropertiesTable;
        private HabitatPropertiesTable habitatPropertiesTable;
        private ZonePropertiesTable zonePropertiesTable;

        public ConfirmButton() : base()
        {
            this.Text = "Confirm";            
        }

        public ConfirmButton(EmployeePropertiesTable parentTable) : this()
        {
            employeePropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddEmployeeButton_Click);
        }
        /*
        public ConfirmButton(AnimalPropertiesTable parentTable) : this()
        {
            animalPropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddAnimalButton_Click);
        }
        public ConfirmButton(HabitatPropertiesTable parentTable) : this()
        {
            habitatPropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddHabitatButton_Click);
        }
        public ConfirmButton(ZonePropertiesTable parentTable) : this()
        {
            zonePropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddZoneButton_Click);
        }
        */

        private void AddEmployeeButton_Click(object? sender, EventArgs e)
        {
            employeePropertiesTable.ButtonClick();
        }

        /*
        private void AddAnimalButton_Click(object? sender, EventArgs e)
        {
            animalPropertiesTable.ButtonClick();
        }

        private void AddHabitatButton_Click(object? sender, EventArgs e)
        {
            habitatPropertiesTable.ButtonClick();
        }

        private void AddZoneButton_Click(object? sender, EventArgs e)
        {
            zonePropertiesTable.ButtonClick();
        }
        */
    }
}
