using System.Drawing;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_Windows_Forms_Application.Theme;
using ZooBazaar_DomainModels.Models;


namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalDetailsTable : TableLayoutPanel
    {
        private Label _animalName;
        private Label _animalSpecies;
        private Label _animalHabitat;
        private Label _animalZone;
        private List<Label> _labels;
        private Button _animalMoreInfo;
        public AnimalDetailsTable(Animal animal, AnimalTable animalTable)
        {
            //assigning controls
            _labels = new List<Label>();

            _animalName = new Label();
            _animalName.Text = animal.Name;
            _labels.Add(_animalName);

            _animalSpecies = new Label();
            _animalSpecies.Text = animal.Species;
            _labels.Add(_animalSpecies);

            _animalHabitat = new Label();
            _animalHabitat.Text = animal.Habitat.ToString();
            _labels.Add(_animalHabitat);

            _animalZone = new Label();
            _animalZone.Text = animal.Zone.ToString();
            _labels.Add(_animalZone);

            foreach (Label _label in _labels)
            {
                _label.Height = 50;
                _label.Dock = DockStyle.Fill;
                _label.BackColor = Color.LightGray;
                _label.Margin = new Padding(0, 0, 1, 0);
                _label.TextAlign = ContentAlignment.MiddleLeft;
            }

            _animalMoreInfo = new aInformationButton(animal, animalTable);

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;
            Margin = new Padding(5, 0, 5, 5);


            //Table styles
            RowCount = 1;
            RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

            ColumnCount = 5;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 50));

            //Adding controls
            Controls.Add(_animalName, 0, 0);
            Controls.Add(_animalSpecies, 1, 0);
            Controls.Add(_animalHabitat, 2, 0);
            Controls.Add(_animalZone, 3, 0);
            Controls.Add(_animalMoreInfo, 4, 0);
        }

        public class aInformationButton : Button
        {
            private AnimalInformationForm animalForm;
            private Animal CurrentAnimal;
            private AnimalTable AnimalTable;

            public aInformationButton(Animal animal, AnimalTable animalTable)
            {

                CurrentAnimal = animal;
                this.AnimalTable = animalTable;

                //properties
                Text = "...";
                Dock = DockStyle.Fill;
                Height = 50;
                BackColor = ThemeColors.highlightColor;
                FlatStyle = FlatStyle.Flat;
                FlatAppearance.BorderSize = 0;
                TextAlign = ContentAlignment.MiddleCenter;
                Font = new Font("Calibri", 14, FontStyle.Bold);
                Margin = Padding.Empty;


                //events
                this.Click += new System.EventHandler(this.InformationButton_Click);


            }

            private void InformationButton_Click(object? sender, EventArgs e)
            {
                animalForm = new AnimalInformationForm(CurrentAnimal, AnimalTable);
                animalForm.Show();
            }
        }
    }
}