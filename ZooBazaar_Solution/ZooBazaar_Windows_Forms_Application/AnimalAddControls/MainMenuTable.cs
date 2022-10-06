using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_DomainModels.Models;
using System.ComponentModel.DataAnnotations;

namespace ZooBazaar_Windows_Forms_Application.AnimalAddControls
{
    public class MainMenuTable : TableLayoutPanel
    {
        private IAnimalMenager animalMenager;
        //Fields
        private AnimalAdd animalAdd;
        private Label[] labels;
        private TextBox[] textboxes;
        private NumericUpDown[] numericupdowns;
        private RadioButton[] radioButtons;
        private ComboBox comboBoxSpeciesType;

        private ComboBox TimeBlockInformationComboBox;
        private ComboBox ZoneInformationComboBox;
        private ComboBox HabitatInformationComboBox;


        private ITimeBlockMenager TimeBlockMenager;
        private List<TimeBlock> Timeblocks;
        private IHabitatMenager HabitatMenager;
        private List<Habitat> Habitats;
        private IZoneMenager ZoneMenager;
        private List<Zone> Zones;

        private string[] labelText;
        private string[] radioButtonsText;

        //Controls
        private AddAnimalButton btAdd;
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

        public MainMenuTable(AnimalAdd animalAdd)
        {
            this.animalMenager = Program.GetService<IAnimalMenager>();
            this.animalAdd = animalAdd;
            //Fields
            labels = new Label[11];
            textboxes = new TextBox[3];
            numericupdowns = new NumericUpDown[5];
            radioButtons = new RadioButton[2];
            comboBoxSpeciesType = new ComboBox();
            labelText = new string[] { "Name", "Age", "DateOfBirth", "Sex", "Species", "SpeciesType", "Diet", "FeedingTime", "FeedingInterval", "Zone", "Habitat" };
            radioButtonsText = new string[] { "Male", "Female"};


            this.TimeBlockMenager = Program.GetService<ITimeBlockMenager>();
            this.Timeblocks = new List<TimeBlock>(TimeBlockMenager.GetAll());
            this.HabitatMenager = Program.GetService<IHabitatMenager>();
            this.Habitats = new List<Habitat>(HabitatMenager.GetAll());
            this.ZoneMenager = Program.GetService<IZoneMenager>();
            this.Zones = new List<Zone>(ZoneMenager.GetAll());


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
                //textboxes[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                textboxes[i].Dock = DockStyle.Fill;
                textboxes[i].Margin = new Padding(0, 0, 0, 1);
            }

            for (int i = 0; i < numericupdowns.Length; i++)
            {
                numericupdowns[i] = new NumericUpDown();
                //numericupdowns[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                numericupdowns[i].Dock = DockStyle.Fill;
                numericupdowns[i].Margin = new Padding(0, 0, 0, 1);
            }
            numericupdowns[1].Minimum = 1;
            numericupdowns[1].Maximum = 24;

            dateTimePicker = new DateTimePicker();
            //dateTimePicker.Font = new Font("Calibri", 21, FontStyle.Regular);
            dateTimePicker.Dock = DockStyle.Fill;
            dateTimePicker.Margin = new Padding(0, 0, 0, 1);

            for (int i = 0; i < radioButtons.Length; i++)
            {
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = radioButtonsText[i];
                //radioButtons[i].Font = new Font("Calibri", 21, FontStyle.Regular);
                radioButtons[i].Dock = DockStyle.Fill;
                radioButtons[i].Margin = new Padding(0, 0, 0, 1);
            }
            radioButtons[0].Checked = true;

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

            comboBoxSpeciesType.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBoxSpeciesType.Font = new Font("Calibri", 21, FontStyle.Regular);
            comboBoxSpeciesType.Dock = DockStyle.Fill;
            comboBoxSpeciesType.Margin = new Padding(0, 0, 0, 1);
            comboBoxSpeciesType.DataSource = Enum.GetValues(typeof(SPECIESTYPE));

            comboBoxSpeciesType.SelectedItem = SPECIESTYPE.Mammals;

            //feedingtimeID
            TimeBlockInformationComboBox = new ComboBox();
            foreach (TimeBlock timeBlock in Timeblocks)
            {
                TimeBlockInformationComboBox.Items.Add(timeBlock.ToString());
            }
            TimeBlockInformationComboBox.SelectedIndex = 0; // HOW DO I GET THE DEFAULT VALUE OF WHICH TIMEBLOCK CURRENTLY IS SELECTED?
            TimeBlockInformationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            TimeBlockInformationComboBox.Dock = DockStyle.Fill;

            //zoneid
            ZoneInformationComboBox = new ComboBox();
            foreach (Zone zone in Zones)
            {
                ZoneInformationComboBox.Items.Add(zone.ToString());
            }
            ZoneInformationComboBox.SelectedIndex = 0; // HOW DO I GET THE DEFAULT VALUE OF WHICH ZONE CURRENTLY IS SELECTED?
            ZoneInformationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ZoneInformationComboBox.Dock = DockStyle.Fill;

            //habitatid
            HabitatInformationComboBox = new ComboBox();
            foreach (Habitat habitat in Habitats)
            {
                HabitatInformationComboBox.Items.Add(habitat.ToString());
            }
            HabitatInformationComboBox.SelectedIndex = 0; // HOW DO I GET THE DEFAULT VALUE OF WHICH HABITAT CURRENTLY IS SELECTED?
            HabitatInformationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            HabitatInformationComboBox.Dock = DockStyle.Fill;


            btAdd = new AddAnimalButton(this);

            //Properties
            Dock = DockStyle.Fill;
            Padding = Padding.Empty;
            Margin = Padding.Empty;

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
            Controls.Add(comboBoxSpeciesType, 1, 5);
            Controls.Add(textboxes[2], 1, 6);
            Controls.Add(TimeBlockInformationComboBox, 1, 7);
            Controls.Add(numericupdowns[1], 1, 8);
            Controls.Add(ZoneInformationComboBox, 1, 9);
            Controls.Add(HabitatInformationComboBox, 1, 10);

            for (int i = 0; i < labels.Length; i++)
            {
                Controls.Add(labels[i], 0, i);
            }
            Controls.Add(btAdd, 0, RowCount-1);
            SetColumnSpan(btAdd, ColumnCount);
        }


        public void ButtonClick()
        {
            AnimalAddDTO animalAddDTO = new AnimalAddDTO()
            {
                Name = textboxes[0].Text,
                Age = (int)numericupdowns[0].Value,
                DateOfBirth = dateTimePicker.Value,
                Sex = radioButtons[0].Checked,
                Species = textboxes[1].Text,
                SpeciesType = comboBoxSpeciesType.SelectedItem.ToString(),
                Diet = textboxes[2].Text,
                FeedingTimeID = TimeBlockInformationComboBox.SelectedIndex + 1,
                FeedingInterval = (int)numericupdowns[1].Value,
                ZoneID = ZoneInformationComboBox.SelectedIndex + 1,
                HabitatID = HabitatInformationComboBox.SelectedIndex + 1
            };

            ValidationContext context = new ValidationContext(animalAddDTO, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(animalAddDTO, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    MessageBox.Show(result.ErrorMessage);
                    return;
                }
            }

            animalMenager.NewAnimal(animalAddDTO);

            animalAdd.Close();
        }
    }
}
