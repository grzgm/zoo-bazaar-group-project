using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalTable : TableLayoutPanel
    {
        private List<AnimalDetailsTable> animalDetailsTable;

        public AnimalTable()
        {
            //assigning variables

            //assigning controls
            animalDetailsTable = new List<AnimalDetailsTable>();
            for (int i = 0; i < 5; i++)
            {
                animalDetailsTable.Add(new AnimalDetailsTable("Animal", "Animal", "Animal", "Animal"));
            }



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //table style
            RowCount = animalDetailsTable.Count;

            for (int i = 0; i < animalDetailsTable.Count; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            }

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));


            //adding controls

            // -1 cuz last animal is streched ikd why
            for (int i = 0; i < animalDetailsTable.Count-1; i++)
            {
                Controls.Add(animalDetailsTable[i], 0, i);
            }

            //debug
            //BackColor = Color.Blue;
        }
    }
}
