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

        [BindProperty]
        public int habitatID { get; set; }
        [BindProperty]
        public int zoneID { get; set; }
        [BindProperty]
        public int timeblockID { get; set; }


        public SelectList HabitatsOptions { get; set; }

        public SelectList ZonesOptions { get; set; }
        public SelectList TimeBlockOptions { get; set; }


        public AnimalDetailsModel(IAnimalMenager animalMenager,IHabitatMenager habitatMenager, ITimeBlockMenager timeBlockMenager, IZoneMenager zoneMenager)
        {
            animalDTO = new AnimalDTO();
               _animalMenager = animalMenager;
            _habitatMenager = habitatMenager;
            _timeBlockMenager = timeBlockMenager;
            _zoneMenager = zoneMenager;

            Dictionary<int, string> habitats = _habitatMenager.GetAllDTO().ToDictionary(x => x.HabitatID, v => v.Name);
            Dictionary<int, string> zones = _zoneMenager.GetAllDTO().ToDictionary(x => x.ZoneID, v => v.Name);
            Dictionary<int, string> timeblock = _timeBlockMenager.GetAllDTO().ToDictionary(x => x.TimeblockID, v => v.StartingTime.ToString() + " " + v.EndingTime.ToString());
            HabitatsOptions = new SelectList(habitats, "Key", "Value");
            ZonesOptions = new SelectList(zones, "Key", "Value");
            TimeBlockOptions = new SelectList(timeblock, "Key", "Value");


        }

        public void OnGet(int postId)
        {
            this.ID = postId;
            animalDTO = _animalMenager.GetAnimalDTO(postId);

        }

        public IActionResult OnPostUpdate()
        {
            animalDTO.HabitatDTO = _habitatMenager.GetHabitatDTO(habitatID);
            animalDTO.HabitatDTO.ZoneDTO = _zoneMenager.GetZoneDTO(zoneID);
            animalDTO.TimeBlockDTO = _timeBlockMenager.GetTimeblockDTO(timeblockID);

           

            if (ModelState.IsValid)
            {
                _animalMenager.UpdateAnimal(animalDTO);
                return new RedirectToPageResult("AnimalList");

            }
            else
            {
                return Page();

            }


        }

    }
}
