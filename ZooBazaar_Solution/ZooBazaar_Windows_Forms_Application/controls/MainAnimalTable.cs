using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainAnimalTable : TableLayoutPanel
    {
        //controls
        private AnimalNavBarTable _AnimalNavBarTable;
        private AnimalTable _AnimalTable;
        private AnimalActivityTable _ActivityTable;




        public MainAnimalTable()
        {
            //controls
            _AnimalNavBarTable = new AnimalNavBarTable();
            _AnimalTable = new AnimalTable();
            _ActivityTable = new AnimalActivityTable(_AnimalTable);



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;

            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Controls.Add(_AnimalNavBarTable, 0, 0);
            Controls.Add(_AnimalTable, 0, 1);
            Controls.Add(_ActivityTable, 0, 2);
            /*debug
            Panel testpanel = new Panel();
            testpanel.Dock = DockStyle.Fill;
            testpanel.BackColor = Color.Red;
            testpanel.Margin = Padding.Empty;
            Controls.Add(testpanel, 0, 2);
            */
        }
    }
}