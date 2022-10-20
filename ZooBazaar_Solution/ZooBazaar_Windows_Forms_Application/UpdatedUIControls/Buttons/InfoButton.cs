using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Tables;

namespace ZooBazaar_Windows_Forms_Application.UpdatedUIControls.Buttons
{
    internal class InfoButton : Button
    {

        private InfoForm infoForm;

        private Employee currentEmployee;
        private Animal currentAnimal;
        private Habitat currentHabitat;
        private Zone currentZone;

        public InfoButton() 
        {
            //properties
            Text = "i";
            Dock = DockStyle.Fill;
            Height = 50;
            BackColor = ThemeColors.highlightColor;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = new Font("Calibri", 14, FontStyle.Bold);
            Margin = Padding.Empty;
        }

        public InfoButton(ElementTable elementTable, Employee employee) : this() 
        {
            currentEmployee = employee;
        }
        public InfoButton(ElementTable elementTable, Animal animal) : this()
        {
            currentAnimal = animal;
        }
        public InfoButton(ElementTable elementTable, Habitat habitat) : this()
        {
            currentHabitat = habitat;
        }
        public InfoButton(ElementTable elementTable, Zone zone) : this()
        {
            currentZone = zone;
        }
    }

    

}
