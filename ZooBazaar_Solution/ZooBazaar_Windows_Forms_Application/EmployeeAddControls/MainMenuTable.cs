using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooBazaar_Windows_Forms_Application.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ZooBazaar_Windows_Forms_Application.EmployeeAddControls
{
    internal class MainMenuTable : TableLayoutPanel
    {
        //Fields
        private EmployeeAdd employeeAdd;
        private Label[] labels;
        private TextBox[] textboxes;
        private NumericUpDown[] numericupdowns;
        private RadioButton[] radioButtons;
        private string[] labelText;
        private string[] radioButtonsText;

        //Controls
        private AddButton btAdd;
        private DateTimePicker dateTimePicker;
        private TableLayoutPanel radioButtonsTable;
        //private Label lbName;
        //private TextBox tbName;
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

        public MainMenuTable(EmployeeAdd employeeAdd)
        {
            this.employeeAdd = employeeAdd;
            //Fields
            labels = new Label[11];
            textboxes = new TextBox[4];
            numericupdowns = new NumericUpDown[5];
            radioButtons = new RadioButton[2];
            labelText = new string[] { "Name", "Age", "DateOfBirth", "Sex", "Species", "SpeciesType", "Diet", "FeedingTime", "FeedingInterval", "Zone", "Habitat" };
            radioButtonsText = new string[] { "Male", "notMale"};

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
            }

            for (int i = 0; i < textboxes.Length; i++)
            {
                textboxes[i] = new TextBox();
                textboxes[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                textboxes[i].Dock = DockStyle.Fill;
                textboxes[i].Margin = new Padding(0, 0, 0, 1);
            }

            for (int i = 0; i < numericupdowns.Length; i++)
            {
                numericupdowns[i] = new NumericUpDown();
                numericupdowns[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                numericupdowns[i].Dock = DockStyle.Fill;
                numericupdowns[i].Margin = new Padding(0, 0, 0, 1);
            }

            dateTimePicker = new DateTimePicker();
            dateTimePicker.Font = new Font("Calibri", 21, FontStyle.Regular);
            dateTimePicker.Dock = DockStyle.Fill;
            dateTimePicker.Margin = new Padding(0, 0, 0, 1);

            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = radioButtonsText[i];
                radioButtons[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                radioButtons[i].Dock = DockStyle.Fill;
                radioButtons[i].Margin = new Padding(0, 0, 0, 1);
            }

            radioButtonsTable = new TableLayoutPanel();
            radioButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            radioButtonsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            radioButtonsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            radioButtonsTable.Dock = DockStyle.Fill;
            radioButtonsTable.Padding = Padding.Empty;
            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtonsTable.Controls.Add(radioButtons[i], i, 0);
            }


            btAdd = new AddButton(this);

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
            Controls.Add(textboxes[0], 1, 0);
            Controls.Add(numericupdowns[0], 1, 1);
            Controls.Add(dateTimePicker, 1, 2);
            Controls.Add(radioButtonsTable, 1, 3);
            Controls.Add(textboxes[1], 1, 4);
            Controls.Add(textboxes[2], 1, 5);
            Controls.Add(textboxes[3], 1, 6);
            Controls.Add(numericupdowns[1], 1, 7);
            Controls.Add(numericupdowns[2], 1, 8);
            Controls.Add(numericupdowns[3], 1, 9);
            Controls.Add(numericupdowns[4], 1, 10);

            for (int i = 0; i < labels.Length; i++)
            {
                Controls.Add(labels[i], 0, i);
            }
            Controls.Add(btAdd, 0, RowCount-1);
            SetColumnSpan(btAdd, ColumnCount);

            ////Colors
            //highlightBrush = new SolidBrush(Color.Green);

            ////Events
            //this.CellPaint += TableLayoutPanel_CellPaint;
        }


        public void ButtonClick()
        {
            //AnimalAddDTO animalAddDTO = new AnimalAddDTO();
            //PropertyInfo[] properties = typeof(AnimalAddDTO).GetProperties();
            //for (int i = 0; i < properties.Length; i++)
            //{
            //    properties[i].SetValue(animalAddDTO, textboxes[i].Text);
            //}
            bool isMale= radioButtons[0].Checked;

            AnimalAddDTO animalAddDTO = new AnimalAddDTO()
            {
                Name = textboxes[0].Text,
                Age = (int)numericupdowns[0].Value,
                DateOfBirth = new DateTime(),
                //Sex = isMale,
                Sex = radioButtons[0].Checked,
                Species = textboxes[1].Text,
                SpeciesType = textboxes[2].Text,
                Diet = textboxes[3].Text,
                FeedingTimeID = (int)numericupdowns[1].Value,
                FeedingInterval = (int)numericupdowns[2].Value,
                ZoneID = (int)numericupdowns[3].Value,
                HabitatID = (int)numericupdowns[4].Value
            };
            employeeAdd.Close();
        }


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
