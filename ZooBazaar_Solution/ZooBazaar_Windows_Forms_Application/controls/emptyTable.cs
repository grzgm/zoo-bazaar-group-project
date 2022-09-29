using System.Drawing.Printing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class emptyTable : TableLayoutPanel
    {
        public emptyTable()
        {
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            //BackColor = Color.Red;
        }
    }
}