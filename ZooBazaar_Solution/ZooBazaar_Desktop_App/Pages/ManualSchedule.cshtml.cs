using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using System.Reflection;
using static ZooBazaar_Desktop_App.Pages.ManualScheduleModel;
using System.Diagnostics.Contracts;
using ZooBazaar_ClassLibrary.Menagers;

namespace ZooBazaar_Desktop_App.Pages
{
    public class ManualScheduleModel : PageModel
    {
        private readonly IStaticScheduleManager _staticScheduleManager;
        private readonly ITaskManager _taskManager;
        private readonly IEmployeeMenager _employeeMenager;
        private readonly IAutomaticScheduleManager _automaticScheduleManager;
        private readonly IScheduleManager _scheduleManager;
        private readonly IUnavailabilityScheduleMenager _unavailabilityScheduleMenager;

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

        public DateOnly[] datesOfWeek { get; set; }
        public string[] namesOfDaysOfWeek = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        public static DateTime CurrentDate { get; set; } = DateTime.Now;

        public struct Block
        {
            public StaticSchedule blockSchedule;
            public List<Employee> employees;
            public int amountOfEmployes;
            public DateOnly date;
        }

        public List<Block> Blocks { get; set; }

        public ManualScheduleModel(IStaticScheduleManager staticScheduleManager,IScheduleManager scheduleManager ,ITaskManager taskManager, IEmployeeMenager employeeMenager, IAutomaticScheduleManager automaticScheduleManager, IUnavailabilityScheduleMenager unavailabilityScheduleMenager)
        {
            _staticScheduleManager = staticScheduleManager;
            _taskManager = taskManager;
            _employeeMenager = employeeMenager;
            _automaticScheduleManager= automaticScheduleManager;
            _scheduleManager= scheduleManager;
            _unavailabilityScheduleMenager= unavailabilityScheduleMenager;
            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];

            }
        }
        public void OnGet()
        {
            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];
            }
            

            GetWeekSchedule(CurrentDate);
            LoadEmployees();
        }



        public IActionResult OnPostAutomate()
        {
            DateTime dt = CurrentDate;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            DateTime mondayOftheWeek;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            mondayOftheWeek = dt.AddDays(-1 * diff).Date;

            _automaticScheduleManager.MakeSchedule(DateOnly.FromDateTime(mondayOftheWeek));

            return RedirectToPage("ManualSchedule");
        }


        public IActionResult OnPostAddEmployee(int employeeID, int day, int month, int year, int taskID, int timeblockID, int amountOfEmployees, int amountOfNeededEmployees)
        {


            if(amountOfEmployees < amountOfNeededEmployees && (_scheduleManager.DoesEmplyeeIsAssignedToTaskTimeBlockDate(day, month, year, taskID, timeblockID, employeeID) == false) 
                && (!_unavailabilityScheduleMenager.GetByEmployeeIDDayMonthYear(employeeID, day, month, year).Any()))
            {
                ScheduleAddDTO scheduleAddDTO = new ScheduleAddDTO
                {
                    EmployeeID= employeeID,
                    TaskID= taskID,
                    TimeblockID = timeblockID,
                    Day = day,
                    Month= month,
                    Year= year,
                    
                };

                _scheduleManager.Insert(scheduleAddDTO);

            }
            else
            {
                var resultNotAdded = new { amountOfEmployees = "full" };

                return new JsonResult(resultNotAdded);
            }

            var result = new { amountOfEmployees = _scheduleManager.AmountOfEmployessAssignedToTaskTimeBlockDate(day, month, year, taskID, timeblockID) };

            return new JsonResult(result);

        }
        public IActionResult OnGetGetEmployeesOfTask(int day, int month, int year, int taskID, int timeblockID)
        {
            List<Employee> Employees = _employeeMenager.GetEmployessAssignedToTaskTimeBlockDate(day, month, year, taskID, timeblockID);

            var result = new { employees = Employees};
            return new JsonResult(result);
        }

        public IActionResult OnPostRemoveEmployee(int employeeID, int day, int month, int year, int taskID, int timeblockID)
        {

            _scheduleManager.DeleteByTaskTimeBlockEmployeeDate(day, month, year, taskID, timeblockID, employeeID);
            var result = new { amountOfEmployees = _scheduleManager.AmountOfEmployessAssignedToTaskTimeBlockDate(day, month, year, taskID, timeblockID) };

            return new JsonResult(result);
        }

        public void GenarteDatesOfTheWeek(DateTime date)
        {
            DateTime dt = date;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            DateTime mondayOftheWeek;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            mondayOftheWeek = dt.AddDays(-1 * diff).Date;
            datesOfWeek = new DateOnly[7];
            for(int i = 0; i < 7; i++)
            {
                datesOfWeek[i] = DateOnly.FromDateTime(mondayOftheWeek.AddDays(i).Date);
            }
        }
        private void GetWeekSchedule(DateTime date)
        {
            GenarteDatesOfTheWeek(date);

            List<StaticSchedule> scheduleList = new List<StaticSchedule>();
            Blocks = new List<Block>();
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
                        Blocks.Add(new Block { 
                            blockSchedule = block, 
                            amountOfEmployes = _scheduleManager.AmountOfEmployessAssignedToTaskTimeBlockDate(datesOfWeek[i].Day, datesOfWeek[i].Month, datesOfWeek[i].Year, block.TaskID, block.timeBlockId), 
                            date = datesOfWeek[i],
                            employees = _employeeMenager.GetEmployessAssignedToTaskTimeBlockDate(datesOfWeek[i].Day, datesOfWeek[i].Month, datesOfWeek[i].Year, block.TaskID, block.timeBlockId),
                        });
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

        public IActionResult OnPostNext()
        {
            CurrentDate = CurrentDate.AddDays(7);
            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];
            }

            GetWeekSchedule(CurrentDate);
            LoadEmployees();

            return Page();
        }
        public IActionResult OnPostPrevious()
        {
            CurrentDate = CurrentDate.AddDays(-7);
            schedule = new StaticSchedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new StaticSchedule[24];
            }

            GetWeekSchedule(CurrentDate);
            LoadEmployees();

            return Page();
        }

    }
}
