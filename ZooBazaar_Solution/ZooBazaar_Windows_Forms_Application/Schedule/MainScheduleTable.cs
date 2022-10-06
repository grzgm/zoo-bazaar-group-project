using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.Schedule
{
    internal class MainScheduleTable : TableLayoutPanel
    {

        /*
         * this class needs to be able to get the schedule by week.
         * 
         */

        //fields
        private int weekNr;



        //controls
        private NavBarTable _NavBarTable;
        private Label _WeekLabel;
        private ScheduleTable _ScheduleTable;
        private ActivityTable _ActivityTable;
        



        public MainScheduleTable()
        {
            //controls
            _NavBarTable = new NavBarTable(this);
            _WeekLabel = new Label();
            _WeekLabel.Text = "Week 10";
            _WeekLabel.TextAlign = ContentAlignment.MiddleCenter;
            _WeekLabel.Height = 40;
            _WeekLabel.Dock = DockStyle.Fill;
            //_WeekLabel.BackColor = Color.RebeccaPurple;
            _WeekLabel.Font = new Font("Calibri", 14, FontStyle.Bold);
            _ScheduleTable = new ScheduleTable(this);
            _ActivityTable = new ActivityTable(99 ,99);



            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            //BackColor = Color.Red;

            RowCount = 4;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            Controls.Add(_NavBarTable, 0, 0);
            Controls.Add(_WeekLabel, 0, 1);
            Controls.Add(_ScheduleTable, 0, 2);
            Controls.Add(_ActivityTable, 0, 3);
        }

        public void LoadNextWeek() 
        {
            ClearScheduleTable();
            _ScheduleTable = new ScheduleTable(this);

            weekNr++; // get week nr from database where the week nuber is 1 more than current week loaded { weeknr = Calledfuntion(); }
            UpdateWeekLabel();

            Controls.Add(_ScheduleTable, 0, 2);

        }
        public void LoadPreviousWeek() 
        {
            ClearScheduleTable();
            _ScheduleTable = new ScheduleTable(this);

            weekNr--; // get week nr from database where the week nuber is 1 less than current week loaded  { weeknr = Calledfuntion(); }
            UpdateWeekLabel();

            Controls.Add(_ScheduleTable, 0, 2);

        }
        public void LoadCurrentWeek()
        {
            ClearScheduleTable();
            _ScheduleTable = new ScheduleTable(this);

            weekNr = 10; // get week nr from database which includes todays date  { weeknr = Calledfuntion(); }
            UpdateWeekLabel();

            Controls.Add(_ScheduleTable, 0, 2);


        }
        public void LoadUpcommingWeek()
        {
            ClearScheduleTable();

        }
        private void ClearScheduleTable()
        {
            Controls.Remove(GetControlFromPosition(0, 2));
        }
        private void ClearActivityTable()
        {
            Controls.Remove(GetControlFromPosition(0, 3));
        }

        public void LoadActivityTable(int dayID, int timeID)
        {
            ClearActivityTable();
            _ActivityTable = new ActivityTable(dayID, timeID);
            Controls.Add(_ActivityTable, 0, 3);
        }

        private void UpdateWeekLabel()
        {
            _WeekLabel.Text = String.Format("Week {0}", weekNr);
        }
    }
}
