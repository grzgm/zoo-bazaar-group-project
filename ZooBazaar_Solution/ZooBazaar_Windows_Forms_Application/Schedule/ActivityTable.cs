using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.Schedule
{
    internal class ActivityTable : TableLayoutPanel
    {
        int dayID;
        int timeID;

        Label debug = new Label();
        public ActivityTable(int dayID, int timeID)
        {
            this.dayID = dayID;
            this.timeID = timeID;

            Dock = DockStyle.Fill;
            //BackColor = Color.Yellow;

            debug.Text = String.Format("day: {0} - time: {1}", dayID, timeID);
            Controls.Add(debug);

        }
    }
}
