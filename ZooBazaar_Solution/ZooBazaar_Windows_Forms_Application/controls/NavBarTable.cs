﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class NavBarTable : TableLayoutPanel
    {
        private MainScheduleTable mainScheduleTable;


        private ComboBox _TypeComboBox;
        private ComboBox _ComboBox;

        private PreviousWeekButton _PreviousButton;
        private CurrentWeekButton _CurrentButton;
        private NextWeekButton _NextButton;

        private NewScheduleButton _NewScheduleButton;


        public NavBarTable(MainScheduleTable mainScheduleTable)
        {
            //fields
            this.mainScheduleTable = mainScheduleTable;

            //assigning controls
            _TypeComboBox = new ComboBox();
            _TypeComboBox.Dock = DockStyle.Fill;
            _ComboBox = new ComboBox();
            _ComboBox.Dock = DockStyle.Fill;

            _PreviousButton = new PreviousWeekButton(mainScheduleTable);
            _CurrentButton = new CurrentWeekButton(mainScheduleTable);
            _NextButton = new NextWeekButton(mainScheduleTable);
   

            _NewScheduleButton = new NewScheduleButton();

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            ColumnCount = 7;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));

            //Adding controls
            Controls.Add(_TypeComboBox, 0, 0);
            Controls.Add(_ComboBox, 1, 0);
            Controls.Add(_PreviousButton, 3, 0);
            Controls.Add(_CurrentButton, 4, 0);
            Controls.Add(_NextButton, 5, 0);
            Controls.Add(_NewScheduleButton, 6,0);

        }

    }

    internal class NewScheduleButton : Button
    {
        public NewScheduleButton()
        {
            Dock = DockStyle.Fill;
            Text = "New schedule";
        }
    }

    internal class NextWeekButton : Button
    {
        private MainScheduleTable _mainScheduleTable;
        public NextWeekButton(MainScheduleTable mainScheduleTable)
        {
            //fields
            this._mainScheduleTable = mainScheduleTable;

            //properties
            Dock = DockStyle.Fill;
            Text = ">";

            //events
            this.Click += new System.EventHandler(this.NextWeekButton_Click);
        }
        
        private void NextWeekButton_Click(object? sender, EventArgs e)
        {
            _mainScheduleTable.LoadNextWeek();
        }
    }

    internal class PreviousWeekButton : Button
    {
        private MainScheduleTable _mainScheduleTable;
        public PreviousWeekButton(MainScheduleTable mainScheduleTable)
        {
            //fields
            this._mainScheduleTable = mainScheduleTable;

            //properties
            Dock = DockStyle.Fill;
            Text = "<";

            //events
            this.Click += new System.EventHandler(this.PreviousWeekButton_Click);
        }

        private void PreviousWeekButton_Click(object? sender, EventArgs e)
        {
            _mainScheduleTable.LoadPreviousWeek();
        }
    }

    internal class CurrentWeekButton : Button
    {
        private MainScheduleTable _mainScheduleTable;
        public CurrentWeekButton(MainScheduleTable mainScheduleTable)
        {
            //fields
            this._mainScheduleTable = mainScheduleTable;

            //properties
            Dock = DockStyle.Fill;
            Text = "Today";

            //events
            this.Click += new System.EventHandler(this.CurrentWeekButton_Click);
        }

        private void CurrentWeekButton_Click(object? sender, EventArgs e)
        {
            _mainScheduleTable.LoadCurrentWeek();
        }
    }
}
