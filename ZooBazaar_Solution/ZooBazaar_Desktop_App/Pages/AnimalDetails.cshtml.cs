using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;


namespace ZooBazaar_Desktop_App.Pages
{
    public class AnimalDetailsModel : PageModel
    {


        private readonly IAnimalMenager _animalMenager;

        private readonly IHabitatMenager _habitatMenager;

        private readonly ITimeBlockMenager _timeBlockMenager;

        private readonly IZoneMenager _zoneMenager;

        [BindProperty]
        public int ID { get; set; }

        [BindProperty]
        public AnimalDTO animalDTO { get; set; }

        public List<HabitatDTO> habitats { get; set;}


        public List<ZoneDTO> zones { get; set; }
   

        public List<TimeBlockDTO> timeBlocks { get; set; }


        public AnimalDetailsModel(IAnimalMenager animalMenager,IHabitatMenager habitatMenager, ITimeBlockMenager timeBlockMenager, IZoneMenager zoneMenager)
        {
            animalDTO = new AnimalDTO();
               _animalMenager = animalMenager;
            _habitatMenager = habitatMenager;
            _timeBlockMenager = timeBlockMenager;
            _zoneMenager = zoneMenager;

            
        }

        public void OnGet(int postId)
        {
            this.ID = postId;
            animalDTO = _animalMenager.GetAnimalDTO(postId);
            habitats = _habitatMenager.GetAllDTO();
            zones = _zoneMenager.GetAllDTO();
            timeBlocks = _timeBlockMenager.GetAllDTO();
          
 
        }

        public IActionResult OnPostUpdate()
        {
            habitats = _habitatMenager.GetAllDTO();
            zones = _zoneMenager.GetAllDTO();
            timeBlocks = _timeBlockMenager.GetAllDTO();

            
            

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
