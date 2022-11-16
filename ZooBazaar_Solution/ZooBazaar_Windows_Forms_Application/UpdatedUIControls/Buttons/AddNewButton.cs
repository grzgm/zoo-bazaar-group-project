using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Theme;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls
{
    internal class AddNewButton : ActionBaseButton
    {
        private MainEmployeeTable parentEmployeeTable;
        private MainAnimalTable parentAnimalTable;
        private MainHabitatTable parentHabitatTable;
        private MainZoneTable parentZoneTable;


        


        public AddNewButton(MainEmployeeTable parentTable) : base()
        {
            this.parentEmployeeTable = parentTable;
            this.Click += new System.EventHandler(this.AddEmployeeButton_Click);
            Text = "+   Add new";
        }
        public AddNewButton(MainAnimalTable parentTable) : base()
        {
            this.parentAnimalTable = parentTable;
            this.Click += new System.EventHandler(this.AddAnimalButton_Click);
            Text = "+   Add new";

        }
        public AddNewButton(MainHabitatTable parentTable) : base()
        {
            this.parentHabitatTable = parentTable;
            this.Click += new System.EventHandler(this.AddHabitatButton_Click);
            Text = "+   Add new";

        }
        public AddNewButton(MainZoneTable parentTable) : base()
        {
            this.parentZoneTable = parentTable;
            this.Click += new System.EventHandler(this.AddZoneButton_Click);
            Text = "+   Add new";

        }


        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            parentEmployeeTable.OpenAddForm();
        }

        private void AddAnimalButton_Click(object sender, EventArgs e)
        {
            parentAnimalTable.OpenAddForm();
        }
        private void AddHabitatButton_Click(object sender, EventArgs e)
        {
            parentHabitatTable.OpenAddForm();
        }
        private void AddZoneButton_Click(object sender, EventArgs e)
        {
            parentZoneTable.OpenAddForm();
        }
    }
}
