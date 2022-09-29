using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class MainScheduleTable : TableLayoutPanel
    {
        public MainScheduleTable()
        {

            //properties
            //Padding = Padding.Empty;
            Margin = Padding.Empty;


            Panel testpanel = new Panel();
            testpanel.Dock = DockStyle.Fill;
            testpanel.BackColor = Color.Red;
            testpanel.Margin = Padding.Empty;
            Controls.Add(testpanel);
        }
    }
}
