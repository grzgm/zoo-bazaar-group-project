using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_Desktop_App.Pages
{
    public class ManualScheduleModel : PageModel
    {
        private readonly IStaticScheduleManager _staticScheduleManager;
        private readonly ITaskManager _taskManager;
        private readonly IEmployeeMenager _employeeMenager;
        private readonly IAutomaticScheduleManager _automaticScheduleManager;

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
        [Required]
        public string employeeID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string employeesNeeded { get; set; }

        public List<SelectListItem> Employees { get; set; }

        public List<List<Schedule>> MakeSchedule { get; set; }

        public ManualScheduleModel(IStaticScheduleManager staticScheduleManager, ITaskManager taskManager, IEmployeeMenager employeeMenager, IAutomaticScheduleManager automaticScheduleManager)
        {
            _staticScheduleManager = staticScheduleManager;
            _taskManager = taskManager;
            _employeeMenager = employeeMenager;
            _automaticScheduleManager= automaticScheduleManager;

            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];
            }
 
            MakeSchedule= new List<List<Schedule>>();
            MakeSchedule = _automaticScheduleManager.MakeSchedule(new DateOnly(2022, 12, 12));
            GetWeekSchedule();
            LoadEmployees();
        }


        public IActionResult OnPostAddEmployee(int i, int j, int employeeID)
        {

            return Page();

        }

        private void GetWeekSchedule()
        {
            List<StaticSchedule> scheduleList = new List<StaticSchedule>();
            for (int i = 0; i < 7; i++)
            {
                int day = i + 1;
                if (day > 6)
                {
                    day = 0;
                }
                scheduleList = _staticScheduleManager.GetScheduleFromDay(day);
                if (scheduleList.Count > 0)
                {
                    foreach (StaticSchedule block in scheduleList)
                    {
                        schedule[i][block.timeBlockId] = block;
                    }
                }
            }
        }

        public void LoadEmployees()
        {
            Employees = new List<SelectListItem>();
            foreach (Employee employee in _employeeMenager.GetAll())
            {
                Employees.Add(new SelectListItem { Text = employee.FirstName + " " + employee.LastName, Value = employee.ID.ToString() });
            }
        }


    }
}
