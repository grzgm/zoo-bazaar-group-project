using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.Schedule
{
    internal class BlockButton : Button
    {
        private MainScheduleTable mainScheduleTable;


        int timeID;
        int dayID;
        public BlockButton(MainScheduleTable mainScheduleTable, int parentDayTableID, int timeID)
        {
            this.timeID = timeID;
            this.dayID = parentDayTableID;

            this.mainScheduleTable = mainScheduleTable;

            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = Color.White;
            BackColor = Color.LightGray;
            BackColor = Color.Pink;

            this.Click += new System.EventHandler(this.BlockButton_Click);
        }

        private void BlockButton_Click(object? sender, System.EventArgs e)
        {
            mainScheduleTable.LoadActivityTable(dayID, timeID);
        }

    }
}
