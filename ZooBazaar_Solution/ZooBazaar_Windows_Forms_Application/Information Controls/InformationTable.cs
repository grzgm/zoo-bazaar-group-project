using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;
using System.ComponentModel.DataAnnotations;

namespace ZooBazaar_Windows_Forms_Application.Information_Controls
{
    public class InformationTable : TableLayoutPanel
    {
        //Animal Variables
        private AnimalInformationForm AnimalInformationForm;
        private Animal Animal;
        private IAnimalMenager AnimalMenager;
        private ITimeBlockMenager TimeBlockMenager;
        private List<TimeBlock> Timeblocks;
        private IHabitatMenager HabitatMenager;
        private List<Habitat> Habitats;
        private IZoneMenager ZoneMenager;
        private List<Zone> Zones;

        //Employee variables
        private EmployeeInformationForm EmployeeInformationForm;
        private Employee Employee;
        private IEmployeeMenager EmployeeMenager;

        private string[] LabelStrings;
        private string[] InformationStrings;

        //other variables
        private bool EditMode;
        private bool IsEmployee; //true object = Employee, false object = Animal

        private Control[] EditControls;


        private InformationTable()
        {
            EditMode = true;
            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            Padding = new Padding(10);


            //events
            this.CellPaint += TableLayoutPanel_CellPaint;
        }
        public InformationTable(AnimalInformationForm parentForm, Animal animal) : this()
        {
            this.AnimalMenager = Program.GetService<IAnimalMenager>();
            this.TimeBlockMenager = Program.GetService<ITimeBlockMenager>();
            this.Timeblocks = new List<TimeBlock>(TimeBlockMenager.GetAll());
            this.HabitatMenager = Program.GetService<IHabitatMenager>();
            this.Habitats = new List<Habitat>(HabitatMenager.GetAll());
            this.ZoneMenager = Program.GetService<IZoneMenager>();
            this.Zones = new List<Zone>(ZoneMenager.GetAll());
            
            LabelStrings = new string[] { "ID", "Name", "Age", "Date of birth", "Sex", "Species", "Species type", "Diet", "Feeding time","Feeding interval", "Zone", "Habitat" };
            InformationStrings = new string[] { animal.ID.ToString(), animal.Name, animal.Age.ToString(), animal.DateOnly.ToString(), animal.Sex.ToString(), animal.Species, animal.SpeciesType.ToString(), animal.Diet.ToString(), animal.TimeBlock.ToString(), animal.FeedingInterval.ToString(), animal.Zone.ToString(), animal.Habitat.ToString() };
            //feeding time zone and habitat display as Zoobazaar_DomainModels.Model... NEEDS TO BE FIXED
            AnimalInformationForm = parentForm;
            Animal = animal;
            IsEmployee = false;
            SetTableStyle();

        }

        public InformationTable(EmployeeInformationForm parentForm, Employee employee) : this()
        {
            this.EmployeeMenager = Program.GetService<IEmployeeMenager>();
            LabelStrings = new string[] { "ID", "First name", "Last name", "Email", "Phone", "Adress", "Role" };
            InformationStrings = new string[] { employee.ID.ToString(), employee.FirstName, employee.LastName, employee.Email, employee.Phone, employee.Address, employee.Role.ToString() };
            EmployeeInformationForm = parentForm;
            Employee = employee;
            IsEmployee = true;
            SetTableStyle();

        }

        private void SetTableStyle()
        {
            //tablestyle
            ColumnCount = 2;
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            RowCount = LabelStrings.Length * 2 + 3;
            for (int i = 0; i < LabelStrings.Length; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 50));
                RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            }
            RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 1));
            RowStyles.Add(new RowStyle(SizeType.Absolute, 200));


            //creates lables for the 1st column
            int y = 0;
            for (int i = 0; i < LabelStrings.Length; i++)
            {
                Label informationLabel = new Label();
                informationLabel.Text = LabelStrings[i];
                informationLabel.Dock = DockStyle.Fill;
                informationLabel.Margin = Padding.Empty;
                informationLabel.BackColor = ThemeColors.secondaryColor;
                informationLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
                informationLabel.TextAlign = ContentAlignment.MiddleLeft;

                Controls.Add(informationLabel, 0, y);
                y += 2;
            }

            UpdateControls();

            //Adding buttons
            Panel ButtonPanel = new Panel();
            ButtonPanel.Dock = DockStyle.Top;
            ButtonPanel.Padding = new Padding(0, 5, 0, 5);
            ButtonPanel.Height = 100;

            aRemoveButton RemoveButton = new aRemoveButton(this);
            aEditButton EditButton = new aEditButton(this);

            ButtonPanel.Controls.Add(EditButton);
            ButtonPanel.Controls.Add(RemoveButton);
            Controls.Add(ButtonPanel, 1, RowCount - 1);

        }

        public void UpdateControls()
        {
            EditMode = !EditMode;
            int row = 0;
            //Add ID Label
            Label IDLabel = new Label();
            IDLabel.Text = InformationStrings[0];
            IDLabel.Dock = DockStyle.Fill;
            IDLabel.Margin = Padding.Empty;
            IDLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
            IDLabel.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(IDLabel, 1, row);

            row = 2;

            //Removes current controls showed
            for (int i = 1; i < LabelStrings.Length * 2; i++)
            {
                Controls.Remove(GetControlFromPosition(1, i));
            }

            if (EditMode)
            {
                
                if (IsEmployee)
                {
                    EditControls = new Control[LabelStrings.Length];
                    for (int i = 1; i < LabelStrings.Length; i++)
                    {
                        Control InformationControl;
                        if (i == LabelStrings.Length - 1)
                        {
                            ComboBox InformationComboBox = new ComboBox();
                            InformationComboBox.DataSource = Enum.GetValues(typeof(ROLE));

                            InformationControl = InformationComboBox;
                        }
                        else
                        {
                            InformationControl = new TextBox();

                        }
                        EditControls[i] = InformationControl;
                        InformationControl.Text = InformationStrings[i];
                        InformationControl.Dock = DockStyle.Fill;
                        InformationControl.Margin = new Padding(0, 15, 0, 15);
                        InformationControl.Font = new Font("Calibri", 12, FontStyle.Regular);

                        Controls.Add(InformationControl, 1, row);
                        row += 2;
                    }
                }
                else if (!IsEmployee)
                {
                    EditControls = new Control[LabelStrings.Length];
                    
                    //name
                    EditControls[1] = new TextBox();
                    EditControls[1].Text = InformationStrings[1];

                    //age
                    EditControls[2] = new NumericUpDown(); 
                    EditControls[2].Text = InformationStrings[2];

                    //Date of birth;
                    DateTimePicker DateControl = new DateTimePicker();
                    DateControl.Value = DateTime.Parse(InformationStrings[3]);
                    EditControls[3] = DateControl; 

                    //sex
                    EditControls[4] = new Panel(); 
                    RadioButton maleRadioButton = new RadioButton(); 
                    maleRadioButton.Text = "Male";
                    maleRadioButton.Dock = DockStyle.Left;
                    RadioButton femaleRadioButton = new RadioButton(); 
                    femaleRadioButton.Text = "Female";
                    femaleRadioButton.Dock = DockStyle.Left;
                    if(InformationStrings[4] == "True" || InformationStrings[4] == "Male")
                    {
                        maleRadioButton.Checked = true;
                    }
                    else { femaleRadioButton.Checked = true; }

                    EditControls[4].Controls.Add(maleRadioButton);
                    EditControls[4].Controls.Add(femaleRadioButton);

                    //species
                    EditControls[5] = new TextBox(); 
                    EditControls[5].Text = InformationStrings[5];

                    //species type
                    EditControls[6] = new ComboBox(); 
                    EditControls[6].Text = InformationStrings[6];

                    //diet
                    EditControls[7] = new TextBox(); 
                    EditControls[7].Text = InformationStrings[7];

                    //feedingtimeID
                    ComboBox TimeBlockInformationComboBox = new ComboBox();
                    foreach(TimeBlock timeBlock in Timeblocks)
                    {
                        TimeBlockInformationComboBox.Items.Add(timeBlock.ToString());
                    }
                    TimeBlockInformationComboBox.SelectedIndex = 1; // HOW DO I GET THE DEFAULT VALUE OF WHICH TIMEBLOCK CURRENTLY IS SELECTED?
                    EditControls[8] = TimeBlockInformationComboBox; 
                    EditControls[8].Text = InformationStrings[8];

                    //feeding interval
                    EditControls[9] = new NumericUpDown(); 
                    EditControls[9].Text = InformationStrings[9];
                    
                    //zoneid
                    ComboBox ZoneInformationComboBox = new ComboBox();
                    foreach (Zone zone in Zones)
                    {
                        ZoneInformationComboBox.Items.Add(zone.ToString());
                    }
                    ZoneInformationComboBox.SelectedIndex = 1; // HOW DO I GET THE DEFAULT VALUE OF WHICH ZONE CURRENTLY IS SELECTED?
                    EditControls[10] = ZoneInformationComboBox; 
                    EditControls[10].Text = InformationStrings[10];

                    //habitatid
                    ComboBox HabitatInformationComboBox = new ComboBox();
                    foreach (Habitat habitat in Habitats)
                    {
                        HabitatInformationComboBox.Items.Add(habitat.ToString());
                    }
                    HabitatInformationComboBox.SelectedIndex = 1; // HOW DO I GET THE DEFAULT VALUE OF WHICH HABITAT CURRENTLY IS SELECTED?
                    EditControls[11] = HabitatInformationComboBox; 
                    EditControls[11].Text = InformationStrings[11];

                    //Adding controls
                    for (int i = 1; i < EditControls.Length; i++)
                    {

                        Controls.Add(EditControls[i], 1, row);
                        row += 2;
                    }
                }   
            }
            else
            {
                for (int i = 1; i < LabelStrings.Length; i++)
                {
                    Label InformationLabel = new Label();
                    InformationLabel.Text = InformationStrings[i];
                    InformationLabel.Dock = DockStyle.Fill;
                    InformationLabel.Margin = Padding.Empty;
                    InformationLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
                    InformationLabel.TextAlign = ContentAlignment.MiddleLeft;

                    Controls.Add(InformationLabel, 1, row);
                    row += 2;
                }
            }
        }

        private void TableLayoutPanel_CellPaint(object? sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(ThemeColors.secondaryColor);
            if (e.Row % 2 != 0)
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
        }
        public bool EditInformation()
        {
            
            if (IsEmployee)
            {
                for (int i = 1; i < InformationStrings.Length; i++)
                {
                    InformationStrings[i] = EditControls[i].Text;
                }

                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.EmployeeID = Int32.Parse(InformationStrings[0]);
                employeeDTO.FirstName = InformationStrings[1];
                employeeDTO.LastName = InformationStrings[2];
                employeeDTO.Email = InformationStrings[3];
                employeeDTO.Phone = InformationStrings[4];
                employeeDTO.Address = InformationStrings[5];
                employeeDTO.Role = InformationStrings[6];



                ValidationContext context = new ValidationContext(employeeDTO, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(employeeDTO, context, errors, true))
                {
                    foreach (ValidationResult result in errors)
                    {
                        MessageBox.Show(result.ErrorMessage);
                        return false;
                    }
                }

                EmployeeMenager.UpdateEmployee(employeeDTO);
                return true;
            }
            else
            {
                for (int i = 1; i < InformationStrings.Length; i++)
                {
                    if (i == 4)
                    {
                        RadioButton checkedRadioButton = EditControls[i].Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
                        InformationStrings[i] = checkedRadioButton.Text;
                    }
                    else if(i == 8 || i == 10 || i == 11)
                    {
                        ComboBox currentComboBox = (ComboBox)EditControls[i];
                        InformationStrings[i] = (currentComboBox.SelectedIndex+1).ToString();
                    }
                    else
                    {
                        InformationStrings[i] = EditControls[i].Text;
                    }
                }
                
                AnimalDTO animalDTO = new AnimalDTO();
                animalDTO.AnimalId = Int32.Parse(InformationStrings[0]);
                animalDTO.Name = InformationStrings[1];
                animalDTO.Age = Int32.Parse(InformationStrings[2]);
                animalDTO.DateOfBirth = DateTime.Parse(InformationStrings[3]);
                if(InformationStrings[4] == "True" || InformationStrings[4] == "Male")
                {
                    animalDTO.Sex = true;
                }
                else
                {
                    animalDTO.Sex = false;
                }
                animalDTO.Species = InformationStrings[5];
                animalDTO.SpeciesType = InformationStrings[6];
                animalDTO.Diet = InformationStrings[7];
                animalDTO.FeedingTimeID = Int32.Parse(InformationStrings[8]);
                animalDTO.FeedingInterval = Int32.Parse(InformationStrings[9]);
                animalDTO.ZoneID = Int32.Parse(InformationStrings[10]);
                animalDTO.HabitatID = Int32.Parse(InformationStrings[11]);



                ValidationContext context = new ValidationContext(animalDTO, null, null);
                IList<ValidationResult> errors = new List<ValidationResult>();

                if (!Validator.TryValidateObject(animalDTO, context, errors, true))
                {
                    foreach (ValidationResult result in errors)
                    {
                        MessageBox.Show(result.ErrorMessage);
                        return false;
                    }
                }

                AnimalMenager.UpdateAnimal(animalDTO);
                return true;
            }
        }

        public void Remove()
        {
            if (IsEmployee)
            {
                EmployeeMenager.RemoveEmployee(Employee.ID);
                EmployeeInformationForm.Close();
            }
            else if (!IsEmployee)
            {
                AnimalMenager.RemoveAnimal(Animal.ID);
                AnimalInformationForm.Close();
            }
        }
    }

    public class aEditButton : Button
    {

        private InformationTable parentTable;
        private bool EditMode;
        public aEditButton(InformationTable parentTable)
        {
            this.parentTable = parentTable;

            EditMode = false;

            Dock = DockStyle.Right;
            Height = 100;
            Width = 200;
            Margin = new Padding(5);
            Text = "Edit";
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ThemeColors.secondaryColor;

            this.Click += new System.EventHandler(EditButton_Click);
        }

        private void EditButton_Click(object? sender, EventArgs e)
        {
            UpdateButton();
            parentTable.UpdateControls();
            this.Click -= new System.EventHandler(EditButton_Click);


        }

        private void EditButton_Save_Click(object? sender, EventArgs e)
        {
            bool check = false;
            check = parentTable.EditInformation();
            if(check)
            {
                parentTable.UpdateControls();
                this.Click -= new System.EventHandler(EditButton_Save_Click);
                UpdateButton();
            }
        }

        private void UpdateButton()
        {
            EditMode = !EditMode;
            if (EditMode)
            {
                Text = "Save";
                this.Click += new System.EventHandler(EditButton_Save_Click);
            }
            else
            {
                Text = "Edit";
                this.Click += new System.EventHandler(EditButton_Click);

            }
        }
    }

    public class aRemoveButton : Button
    {
        InformationTable parentTable;
        public aRemoveButton(InformationTable parentTable)
        {

            this.parentTable = parentTable;

            //properties
            Dock = DockStyle.Right;
            Height = 100;
            Width = 200;
            Margin = new Padding(5);
            Text = "Remove";
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = ThemeColors.secondaryColor;

            //event
            this.Click += new System.EventHandler(RemoveButton_Click);
        }

        private void RemoveButton_Click(object? sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                parentTable.Remove();

            }
            else
            {
                return;
            }

        }
    }
}
