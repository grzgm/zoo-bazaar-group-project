using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class EmployeeNavBarTable : TableLayoutPanel
    {

        private ComboBox _NameComboBox;
        private ComboBox _FunctionComboBox;
        private ComboBox _WorkZoneComboBox;

        public EmployeeNavBarTable()
        {
            //assigning controls
            _NameComboBox = new ComboBox();
            _NameComboBox.Dock = DockStyle.Fill;
            _FunctionComboBox = new ComboBox();
            _FunctionComboBox.Dock = DockStyle.Fill;
            _WorkZoneComboBox = new ComboBox();
            _WorkZoneComboBox.Dock = DockStyle.Fill;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            ColumnCount = 3;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            //Adding controls
            Controls.Add(_NameComboBox, 0, 0);
            Controls.Add(_FunctionComboBox, 1, 0);
            Controls.Add(_WorkZoneComboBox, 2, 0);

            //debug
            //BackColor = Color.Red;
        }

    }
}
