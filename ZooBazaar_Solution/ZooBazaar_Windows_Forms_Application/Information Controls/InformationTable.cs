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

namespace ZooBazaar_Windows_Forms_Application.Information_Controls
{
    public class InformationTable : TableLayoutPanel
    {
        //Animal Variables
        private AnimalInformationForm AnimalInformationForm;
        private Animal Animal;
        private IAnimalMenager AnimalMenager;

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
            LabelStrings = new string[] { "ID", "Name", "Age", "Date of birth", "Sex", "Species", "Species type", "Diet", "Feeding time","Feeding interval", "Zone", "Habitat" };
            InformationStrings = new string[] { animal.ID.ToString(), animal.Name, animal.Age.ToString(), animal.DateOnly.ToString(), animal.Sex.ToString(), animal.Species, animal.SpeciesType.ToString(), animal.Diet, animal.TimeBlock.ToString(), animal.FeedingInterval.ToString(), animal.Zone.ToString(), animal.Habitat.ToString() };

            IsEmployee = false;
            SetTableStyle();

        }

        public InformationTable(EmployeeInformationForm parentForm, Employee employee) : this()
        {
            this.EmployeeMenager = Program.GetService<IEmployeeMenager>();
            LabelStrings = new string[] { "ID", "First name", "Last name", "Email", "Phone", "Adress", "Role" };
            InformationStrings = new string[] { employee.ID.ToString(), employee.FirstName, employee.LastName, employee.Email, employee.Phone, employee.Address, employee.Role.ToString() };

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
            int y = 0;
            //Add ID Label
            Label IDLabel = new Label();
            IDLabel.Text = InformationStrings[0];
            IDLabel.Dock = DockStyle.Fill;
            IDLabel.Margin = Padding.Empty;
            IDLabel.Font = new Font("Calibri", 12, FontStyle.Regular);
            IDLabel.TextAlign = ContentAlignment.MiddleLeft;
            Controls.Add(IDLabel, 1, y);

            y = 2;

            //Removes current controls showed
            for (int i = 1; i < 15; i++)
            {
                Controls.Remove(GetControlFromPosition(1, i));
            }

            if (EditMode)
            {
                /*
                if (IsEmployee)
                {
                    for (int i = 1; i < LabelStrings.Length; i++)
                    {
                        TextBox InformationTextBox = new TextBox();
                        EditControls[i - 1] = InformationTextBox;
                        InformationTextBox.Text = InformationStrings[i];
                        InformationTextBox.Dock = DockStyle.Fill;
                        InformationTextBox.Margin = new Padding(0, 15, 0, 15);
                        InformationTextBox.Font = new Font("Calibri", 12, FontStyle.Regular);

                        Controls.Add(InformationTextBox, 1, y);
                        y += 2;
                    }
                }
                else if (!IsEmployee)
                {
                    EditControls = new Control[LabelStrings.Length + 1];
                    EditControls[1] = new TextBox(); //name
                    EditControls[1].Text = InformationStrings[1];

                    EditControls[2] = new NumericUpDown(); //age
                    EditControls[2].Text = InformationStrings[2];

                    EditControls[3] = new DateTimePicker(); //date of birth
                    EditControls[3].Text = InformationStrings[3];


                    EditControls[4] = new RadioButton(); //sex
                    EditControls[5] = new RadioButton(); //sex
                    EditControls[6] = new TextBox(); //species
                    EditControls[7] = new ComboBox(); //species type
                    EditControls[8] = new TextBox(); //diet
                    EditControls[9] = new NumericUpDown(); //feedingtimeID
                    EditControls[10] = new NumericUpDown(); //feeding interval
                    EditControls[11] = new NumericUpDown(); //zoneid
                    EditControls[12] = new NumericUpDown(); //habitatid

                    




                }
                */
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

                    Controls.Add(InformationLabel, 1, y);
                    y += 2;
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
        public void EditInformation()
        {
            for (int i = 1; i < InformationStrings.Length; i++)
            {
                InformationStrings[i] = EditControls[i - 1].Text;
            }
            if (IsEmployee)
            {
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.Id = Int32.Parse(InformationStrings[0]);
                employeeDTO.FirstName = InformationStrings[1];
                employeeDTO.LastName = InformationStrings[2];
                employeeDTO.Email = InformationStrings[3];
                employeeDTO.Phone = InformationStrings[4];
                employeeDTO.Address = InformationStrings[5];
                employeeDTO.Role = InformationStrings[6];

                EmployeeMenager.UpdateEmployee(employeeDTO);
            }
            else if (!IsEmployee)
            {
                /*
                AnimalDTO animalDTO = new AnimalDTO();
                animalDTO.Id = Int32.Parse(InformationStrings[0]);
                animalDTO.Name = InformationStrings[1];
                animalDTO.Age = Int32.Parse(InformationStrings[2]);
                animalDTO.DateOfBirth = 
                animalDTO.Sex = 
                animalDTO.Species =
                animalDTO.SpeciesType =
                animalDTO.Diet =
                animalDTO.FeedingTimeID =
                animalDTO.FeedingInterval =
                animalDTO.ZoneID =
                animalDTO.HabitatID =

                AnimalMenager.UpdateAnimal(animalDTO);*/
            }
        }

        public void Remove()
        {
            if (IsEmployee)
            {
                EmployeeMenager.RemoveEmployee(Employee.ID);
            }
            else if (!IsEmployee)
            {
                AnimalMenager.RemoveAnimal(Animal.ID);
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

            parentTable.EditInformation();
            parentTable.UpdateControls();
            this.Click -= new System.EventHandler(EditButton_Save_Click);
            UpdateButton();


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
