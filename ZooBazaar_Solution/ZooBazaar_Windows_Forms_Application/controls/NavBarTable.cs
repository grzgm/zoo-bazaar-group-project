using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class NavBarTable : TableLayoutPanel
    {

        private ComboBox _TypeComboBox;
        private ComboBox _ComboBox;

        private Button _PreviousButton;
        private Button _TodayButton;
        private Button _NextButton;

        private Button _NewScheduleButton;


        public NavBarTable()
        {
            //assigning controls
            _TypeComboBox = new ComboBox();
            _TypeComboBox.Dock = DockStyle.Fill;
            _ComboBox = new ComboBox();
            _ComboBox.Dock = DockStyle.Fill;

            _PreviousButton = new Button();
            _PreviousButton.Text = "<";
            _PreviousButton.Dock = DockStyle.Fill;
            _TodayButton = new Button();
            _TodayButton.Text = "Today";
            _TodayButton.Dock = DockStyle.Fill;
            _NextButton = new Button();
            _NextButton.Text = ">";
            _NextButton.Dock = DockStyle.Fill;

            _NewScheduleButton = new Button();
            _NewScheduleButton.Text = "New schedule";
            _NewScheduleButton.Dock = DockStyle.Fill;

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
            Controls.Add(_TodayButton, 4, 0);
            Controls.Add(_NextButton, 5, 0);
            Controls.Add(_NewScheduleButton, 6,0);

        }

    }
}
