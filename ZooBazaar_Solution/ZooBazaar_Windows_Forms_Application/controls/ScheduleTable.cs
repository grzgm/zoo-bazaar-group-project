using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class ScheduleTable : TableLayoutPanel
    {
        private string[] weekDays;
        private DayTable[] _DayTables;
        private TimeTable _TimeTable;

        public ScheduleTable()
        {
            //assigning variables
            weekDays = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            //assigning controls
            _TimeTable = new TimeTable();
            _DayTables = new DayTable[7];
            for (int i = 0; i < 7; i++)
            {
                _DayTables[i] = new DayTable();
            }



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //table style
            RowCount = 2;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            ColumnCount = 8;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100/7));


            //adding controls

            Controls.Add(_TimeTable, 0, 1);
            for (int i = 0; i < _DayTables.Length; i++)
            {
                Controls.Add(_DayTables[i], i + 1, 1);
            }

            for (int i = 0; i < weekDays.Length; i++)
            {
                Label _WeekDayLabel = new Label();
                _WeekDayLabel.Dock = DockStyle.Fill;
                _WeekDayLabel.Text = weekDays[i];
                _WeekDayLabel.TextAlign = ContentAlignment.MiddleCenter;
                _WeekDayLabel.Font = new Font("Calibri", 11, FontStyle.Regular);
                Controls.Add(_WeekDayLabel, i + 1, 0);
            }
        }
    }
}
