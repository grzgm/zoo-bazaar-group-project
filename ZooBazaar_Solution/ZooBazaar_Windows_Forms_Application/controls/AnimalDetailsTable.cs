using System.Drawing;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    internal class AnimalDetailsTable : TableLayoutPanel
    {
        private Label _animalName;
        private Label _animalSpecies;
        private Label _animalHabitat;
        private Label _animalZone;
        private Button _animalMoreInfo;
        public AnimalDetailsTable(string name, string species, string habitat, string zone)
        {
            //assigning controls
            _animalName = new Label();
            _animalName.Text = name;
            _animalName.Dock = DockStyle.Fill;
            _animalName.BackColor = Color.LightGray;
            _animalName.Margin = Padding.Empty;

            _animalSpecies = new Label();
            _animalSpecies.Text = species;
            _animalSpecies.Dock = DockStyle.Fill;
            _animalSpecies.BackColor = Color.LightGray;
            _animalSpecies.Margin = Padding.Empty;

            _animalHabitat = new Label();
            _animalHabitat.Text = habitat;
            _animalHabitat.Dock = DockStyle.Fill;
            _animalHabitat.BackColor = Color.LightGray;
            _animalHabitat.Margin = Padding.Empty;

            _animalZone = new Label();
            _animalZone.Text = zone;
            _animalZone.Dock = DockStyle.Fill;
            _animalZone.BackColor = Color.LightGray;
            _animalZone.Margin = Padding.Empty;

            _animalMoreInfo = new Button();
            _animalMoreInfo.Text = "...";
            _animalMoreInfo.Dock = DockStyle.Fill;
            _animalMoreInfo.Height = 50;
            _animalMoreInfo.BackColor = Color.Green;
            _animalMoreInfo.FlatStyle = FlatStyle.Flat;
            _animalMoreInfo.FlatAppearance.BorderSize = 0;
            _animalMoreInfo.TextAlign = ContentAlignment.MiddleCenter;
            _animalMoreInfo.Font = new Font("Calibri", 14, FontStyle.Bold);
            _animalMoreInfo.Margin = Padding.Empty;

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


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
    }
}