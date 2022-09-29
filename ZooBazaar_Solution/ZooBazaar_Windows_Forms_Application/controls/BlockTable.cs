using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class BlockButton : Button
    {
        public BlockButton()
        {
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = Color.White;
            BackColor = Color.LightGray;
        }
    }
}
