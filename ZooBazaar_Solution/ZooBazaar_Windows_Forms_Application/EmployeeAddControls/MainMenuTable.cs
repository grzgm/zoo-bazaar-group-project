using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ZooBazaar_Windows_Forms_Application.EmployeeAddControls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Fields
        private Label[] labels;
        private TextBox[] textboxes;
        private string[] labelText;

        //Controls
        private Label lbName;
        private TextBox tbName;
        private Button btAdd;
        //private Label lbAge;
        //private TextBox tbAge;
        //private Label lbDateOfBirth;
        //private TextBox tbDateOfBirth;
        //private Label lbSex;
        //private TextBox tbSex;
        //private Label lbSpecies;
        //private TextBox tbSpecies;
        //private Label lbSpeciesType;
        //private TextBox tbSpeciesType;
        //private Label lbDiet;
        //private TextBox tbDiet;
        //private Label lbFeedingTime;
        //private TextBox tbFeedingTime;
        //private Label lbFeedingInterval;
        //private TextBox tbFeedingInterval;
        //private Label lbZone;
        //private TextBox tbZone;
        //private Label lbHabitat;
        //private TextBox tbHabitat;
        //private Panel buttonPanel;

        //Color
        SolidBrush highlightBrush;

        public MainMenuTable()
        {
            //Fields
            labels = new Label[11];
            textboxes = new TextBox[11];
            labelText = new string[] { "Name", "Age", "DateOfBirth", "Sex", "Species", "SpeciesType", "Diet", "FeedingTime", "FeedingInterval", "Zone", "Habitat" };

            //Controls
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Text = labelText[i];
                labels[i].Height = 60;
                labels[i].Dock = DockStyle.Fill;
                labels[i].BackColor = Color.LightGray;
                labels[i].Margin = new Padding(0, 0, 0, 1);
                labels[i].TextAlign = ContentAlignment.MiddleLeft;

                textboxes[i] = new TextBox();
                textboxes[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                textboxes[i].Dock = DockStyle.Fill;
                textboxes[i].Margin = new Padding(0, 0, 0, 1);
            }
            btAdd = new Button();
            btAdd.Dock = DockStyle.Top;
            btAdd.Height = 120;
            btAdd.FlatStyle = FlatStyle.Flat;
            btAdd.FlatAppearance.BorderSize = 0;
            btAdd.Text = "Add New Animal";
            btAdd.TextAlign = ContentAlignment.MiddleCenter;
            btAdd.Font = new Font("Calibri", 14, FontStyle.Bold);
            btAdd.BackColor = Color.White;

            //Properties
            Dock = DockStyle.Fill;
            //Padding = Padding.Empty;
            //Margin = Padding.Empty;

            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            RowCount = labels.Length+1;
            for (int i = 0; i < RowCount; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            }

            //Adding Controls
            for (int i = 0; i < labels.Length; i++)
            {
                Controls.Add(labels[i], 0, i);
                Controls.Add(textboxes[i], 1, i);
            }
            Controls.Add(btAdd, 0, RowCount-1);
            SetColumnSpan(btAdd, ColumnCount);

            ////Colors
            //highlightBrush = new SolidBrush(Color.Green);

            ////Events
            //this.CellPaint += TableLayoutPanel_CellPaint;
        }


        //public void ButtonClick(MenuButton buttonClicked)
        //{
        //    Controls.Remove(GetControlFromPosition(2, 1));
        //    for (int i = 0; i < menuButtons.Length; i++)
        //    {
        //        if (menuButtons[i] == buttonClicked)
        //        {
        //            switch (i)
        //            {
        //                case 0:
        //                    Controls.Add(mainScheduleTable, 2, 1);
        //                    break;
        //                case 1:
        //                    Controls.Add(mainEmployeeTable, 2, 1);
        //                    break;
        //                case 2:
        //                    Controls.Add(mainAnimalTable, 2, 1);
        //                     break;
        //            }
        //        }
        //    }
        //}


        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0 && e.Column == 2)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }


            if (e.Column == 1)
            {
                e.Graphics.FillRectangle(highlightBrush, e.CellBounds);
            }
        }

    }
}
