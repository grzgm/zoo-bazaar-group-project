using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Desktop_App.Pages
{
    public class AddAnimalModel : PageModel
    {
        private readonly IAnimalMenager _animalMenager;

        private readonly IHabitatMenager _habitatMenager;

        private readonly ITimeBlockMenager _timeBlockMenager;

        private readonly IZoneMenager _zoneMenager;

        [BindProperty]
        public AnimalDTO animalDTO { get; set; }


        public AddAnimalModel(IAnimalMenager animalMenager, IHabitatMenager habitatMenager, ITimeBlockMenager timeBlockMenager, IZoneMenager zoneMenager)
        {
            animalDTO = new AnimalDTO();
            _animalMenager = animalMenager;
            _habitatMenager = habitatMenager;
            _timeBlockMenager = timeBlockMenager;
            _zoneMenager = zoneMenager;


        }

        public void OnGet()
        {
            


        }

        public IActionResult OnPostUpdate()
        {

            if (ModelState.IsValid)
            {
                return new RedirectToPageResult("Welcome");

            }
            else
            {


                return Page();

            }


        }
    }
}
