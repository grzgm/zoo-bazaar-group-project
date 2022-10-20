using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.AddEntityControls;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class CancelButton : ActionBaseButton
    {
        private EmployeePropertiesTable employeePropertiesTable;
        private AnimalPropertiesTable animalPropertiesTable;
        private HabitatPropertiesTable habitatPropertiesTable;
        private ZonePropertiesTable zonePropertiesTable;

        public CancelButton() : base()
        {
            this.Text = "Cancel";
        }

        public CancelButton(EmployeePropertiesTable parentTable) : this()
        {
            employeePropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddEmployeeButton_Click);
        }
        /*
        public CancelButton(AnimalPropertiesTable parentTable) : this()
        {
            animalPropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddAnimalButton_Click);
        }
        public CancelButton(HabitatPropertiesTable parentTable) : this()
        {
            habitatPropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddHabitatButton_Click);
        }
        public CancelButton(ZonePropertiesTable parentTable) : this()
        {
            zonePropertiesTable = parentTable;
            this.Click += new System.EventHandler(this.AddZoneButton_Click);
        }
        */

        private void AddEmployeeButton_Click(object? sender, EventArgs e)
        {
            employeePropertiesTable.CloseButtonClick();
        }

        /*
        private void AddAnimalButton_Click(object? sender, EventArgs e)
        {
            animalPropertiesTable.CloseButtonClick();
        }

        private void AddHabitatButton_Click(object? sender, EventArgs e)
        {
            habitatPropertiesTable.CloseButtonClick();
        }

        private void AddZoneButton_Click(object? sender, EventArgs e)
        {
            zonePropertiesTable.CloseButtonClick();
        }
        */
    }
}
