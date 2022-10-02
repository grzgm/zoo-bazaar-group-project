﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalNavBarTable : TableLayoutPanel
    {

        private ComboBox _NameComboBox;
        private ComboBox _SpeciesComboBox;
        private ComboBox _HabitatComboBox;
        private ComboBox _ZoneComboBox;

        public AnimalNavBarTable()
        {
            //assigning controls
            _NameComboBox = new ComboBox();
            _NameComboBox.Dock = DockStyle.Fill;
            _SpeciesComboBox = new ComboBox();
            _SpeciesComboBox.Dock = DockStyle.Fill;
            _HabitatComboBox = new ComboBox();
            _HabitatComboBox.Dock = DockStyle.Fill;
            _ZoneComboBox = new ComboBox();
            _ZoneComboBox.Dock = DockStyle.Fill;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            ColumnCount = 4;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            //Adding controls
            Controls.Add(_NameComboBox, 0, 0);
            Controls.Add(_SpeciesComboBox, 1, 0);
            Controls.Add(_HabitatComboBox, 2, 0);
            Controls.Add(_ZoneComboBox, 3, 0);

            //debug
            //BackColor = Color.Red;
        }

    }
}