using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;
using ZooBazaar_DomainModels.Models;

namespace ZooBazaar_Windows_Forms_Application.controls
{
    public class AnimalTable : TableLayoutPanel
    {
        private IAnimalMenager animalMeneger;

        private List<AnimalDetailsTable> animalDetailsTable;

        public AnimalTable()
        {
            this.animalMeneger = Program.GetService<IAnimalMenager>();
            //Filling table with content
            UpdateTableContent();
            UpdateTable();

            //properties
            Dock = DockStyle.Fill;
            Margin = Padding.Empty;


            //table style
            RowCount = animalDetailsTable.Count;

            for (int i = 0; i < animalDetailsTable.Count; i++)
            {
                RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
            }

            ColumnCount = 1;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        }

        //updates Table content
        private void UpdateTable()
        {
            Controls.Clear();
            for (int i = 0; i < animalDetailsTable.Count; i++)
            {
                Controls.Add(animalDetailsTable[i], 0, i);
            }
            Controls.Add(new Panel());
        }

        //refreshes animal List
        public void UpdateTableContent()
        {
            List<Animal> Animals = animalMeneger.GetAll();

            animalDetailsTable = new List<AnimalDetailsTable>();

            foreach (Animal animal in Animals)
            {
                animalDetailsTable.Add(new AnimalDetailsTable(animal, this));
            }
            UpdateTable();
        }
        public void UpdateTableContentBasedOnSpecies(string sPECIESTYPE)
        {
            IEnumerable<Animal> Animals = animalMeneger.GetAll().Where(species => species.SpeciesType == sPECIESTYPE);

            animalDetailsTable = new List<AnimalDetailsTable>();

            foreach (Animal animal in Animals)
            {
                animalDetailsTable.Add(new AnimalDetailsTable(animal, this));
            }
            UpdateTable();
        }
        public void UpdateTableContentBasedOnHabitat(SPECIESTYPE sPECIESTYPE)
        {
            throw new NotImplementedException();
        }
    }
}