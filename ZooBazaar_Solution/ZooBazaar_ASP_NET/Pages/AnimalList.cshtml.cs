using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ASP_NET.Pages
{
    public class AnimalListModel : PageModel
    {
        private IAnimalRepository animalRepository;
        private IAnimalMenager animalMenager;

        public List<Animal> animals;

        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Species { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Habitat { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Zone { get; set; }

        [BindProperty]
        public string SpecialCareNote { get; set; }

        [BindProperty]
        public int SpecialCareId { get; set; }

        public AnimalListModel()
        {
            animalRepository = new AnimalRepository();
            animalMenager = new AnimalManager(animalRepository);

            animals = animalMenager.GetAll();
        }
        public void OnGet()
        {
        }

        public void OnPostName()
        {
            if (Name == null)
                return;
            animals = animals.FindAll(animal => animal.Name == this.Name);
        }
        public void OnPostSpecies()
        {
            if (Species == null)
                return;
            animals = animals.FindAll(animal => animal.Species == this.Species);
        }
        public void OnPostHabitat()
        {
            if (Habitat == null)
                return;
            animals = animals.FindAll(animal => animal.Habitat.ToString() == this.Habitat);
        }
        public void OnPostZone()
        {
            if (Zone == null)
                return;
            animals = animals.FindAll(animal => animal.Zone.ToString() == this.Zone);
        }
        public void OnPostSpecialCare()
        {
            animalMenager.AddSpecialCare(SpecialCareId, SpecialCareNote);
            animals = animalMenager.GetAll();
        }
    }
}
