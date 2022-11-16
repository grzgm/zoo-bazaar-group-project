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
        public void OnGet()
        {
            animalRepository = new AnimalRepository();
            animalMenager = new AnimalManager(animalRepository);

            animals = animalMenager.GetAll();
        }
    }
}
