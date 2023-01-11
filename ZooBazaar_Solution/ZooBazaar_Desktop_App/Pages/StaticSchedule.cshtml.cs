using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ASP_NET.Pages
{
    public class StaticScheduleModel : PageModel
    {
        private readonly IStaticScheduleManager _staticScheduleManager;
        private readonly ITaskManager _taskManager;
        private readonly IZoneMenager _zoneManager;
        private readonly IHabitatMenager _habitatManager;

        public int closingHour = 22;
        public int startingHour = 6;
        public StaticSchedule[][] schedule;

        [BindProperty(SupportsGet = true)]
        public int weekDay { get; set; }
        [BindProperty(SupportsGet = true)]
        public int timeBlock { get; set; }
        [BindProperty(SupportsGet = true)]
        public int taskName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string zoneID { get; set; }
        [BindProperty(SupportsGet = true)][Required]
        public string habitatID { get; set; }
        public List<SelectListItem> Zones { get; set; }
        public List<SelectListItem> Habitats { get; set; }

        public StaticScheduleModel(IStaticScheduleManager staticScheduleManager, ITaskManager taskManager, IZoneMenager zoneMenager, IHabitatMenager habitatMenager)
        {
            _staticScheduleManager = staticScheduleManager;
            _taskManager = taskManager;
            _zoneManager = zoneMenager;
            _habitatManager = habitatMenager;

            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];
            }
            GetWeekSchedule();
            LoadZones();
            LoadHabitats(0);
        }

        public void OnPost()
        {
            int zoneid = Convert.ToInt32(zoneID);
            GetWeekSchedule();
            LoadZones();
            LoadHabitats(zoneid);
        }
        public IActionResult OnPostCreate()
        {
            int day = weekDay + 1;
            if(day > 6)
            {
                day = 0;
            }
            TaskAddDTO taskAddDTO = new TaskAddDTO() {
                Name = ((TASKNAME)taskName).ToString(),
                AnimalID = null,
                HabitatID = Convert.ToInt32(habitatID),
                ZoneID = Convert.ToInt32(zoneID)
            };
            _taskManager.Insert(taskAddDTO);

            StaticScheduleAddDTO scheduleAddDTO = new StaticScheduleAddDTO()
            {
                DayOfTheWeek = day,
                TimeBlockID = this.timeBlock,
                TaskID = _taskManager.NextID(),
            };

            _staticScheduleManager.AddSchedule(scheduleAddDTO);
            
            return RedirectToPage("StaticSchedule");
        }
        public IActionResult OnPostDelete()
        {
            if (habitatID != null)
            {
                int habitatid = Convert.ToInt32(habitatID);
                int taskid = schedule[weekDay][timeBlock].TaskID;
                TaskAddDTO taskDTO = new TaskAddDTO
                {
                    HabitatID=habitatid,
                    ZoneID= Convert.ToInt32(zoneID)
                };
                _taskManager.UpdateHabitatAndZone(taskid, taskDTO);
                return RedirectToPage("StaticSchedule");
            }
            else
            {
                _staticScheduleManager.RemoveSchedule(schedule[weekDay][timeBlock].Id);
                return RedirectToPage("StaticSchedule");
            }
        }

        private void GetWeekSchedule()
        {
            List<StaticSchedule> scheduleList = new List<StaticSchedule>();
            for (int i = 0; i < 7; i++)
            {
                int day = i + 1;
                if(day > 6)
                {
                    day = 0;
                }
                scheduleList = _staticScheduleManager.GetScheduleFromDay(day);
                if(scheduleList.Count > 0)
                {
                    foreach (StaticSchedule block in scheduleList)
                    {
                        schedule[i][block.timeBlockId] = block;
                    }
                }
            }
        }

        public void LoadZones()
        {
            Zones = new List<SelectListItem>();
            foreach(Zone zone in _zoneManager.GetAll())
            {
                Zones.Add(new SelectListItem { Text = zone.Name, Value = zone.ID.ToString()});
            }
        }

        public void LoadHabitats(int zoneid)
        {
            Habitats = new List<SelectListItem>();
            if (zoneid != 0)
            {
                foreach (Habitat habitat in _habitatManager.GetAll())
                {
                    if (habitat.Zone.ID == zoneid)
                    {
                        Habitats.Add(new SelectListItem { Text = habitat.Name, Value = habitat.ID.ToString() });
                    }
                }
            }
            else
            {
                Habitats.Add(new SelectListItem { Text = "Select a Zone", Value = "" });
            }
        }
    }
}
