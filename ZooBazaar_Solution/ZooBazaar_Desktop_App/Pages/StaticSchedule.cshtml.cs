using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private IScheduleRepository scheduleRepository;
        private ITaskRepository taskRepository;
        private IScheduleManager scheduleManager;

        public DateOnly firstDayOfWeek;
        public int closingHour = 22;
        public int startingHour = 6;
        public Schedule[][] schedule;

        [BindProperty(SupportsGet = true)]
        public int weekDay { get; set; }
        [BindProperty(SupportsGet = true)]
        public int timeBlock { get; set; }
        [BindProperty(SupportsGet = true)]
        public string taskName { get; set; }
        public int weekNumber { get; set; }

        public StaticScheduleModel()
        {
            scheduleRepository = new ScheduleRepository();
            taskRepository = new TaskRepository();
            scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);

            DateTime today = DateTime.Now;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(today);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                today = today.AddDays(3);
            }
            weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            firstDayOfWeek = FirstDayOfWeek(DateOnly.FromDateTime(DateTime.Now));

            schedule = new Schedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new Schedule[24];
            }
            GetWeekSchedule();
        }

        public void OnGet()
        {

        }
        private DateOnly FirstDayOfWeek(DateOnly dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff);
        }
        public IActionResult OnPostCreate()
        {
            TaskDTO taskDTO = new TaskDTO() {
                Name = taskName,
                HabitatDTO = null,
                AnimalDTO = null,
            };
            taskRepository.Insert(taskDTO);

            ScheduleDTO scheduleDTO = new ScheduleDTO()
            {
                Day = DateTime.Now.Day,
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                TimeBlockDTO = new TimeBlockDTO() { TimeblockID = this.timeBlock },
                EmployeeDTO = new EmployeeDTO() { EmployeeID = 2 },
                TaskDTO = new TaskDTO() { TaskID = taskRepository.nextID() },
            };

            scheduleRepository.Insert(scheduleDTO);
            
            return RedirectToPage("StaticSchedule");
        }
        public IActionResult OnPostDelete()
        {
            scheduleRepository.Delete(schedule[weekDay][timeBlock].Id);
            return RedirectToPage("StaticSchedule");
        }

        private void GetWeekSchedule()
        {
            List<Schedule> scheduleList = new List<Schedule>();
            for (int i = 0; i < 7; i++)
            {
                scheduleList = scheduleManager.GetDayScheduleEmployeeAllSchdules(firstDayOfWeek.AddDays(i), 2);
                if(scheduleList.Count > 0)
                {
                    foreach (Schedule block in scheduleList)
                    {
                        schedule[i][block.timeBlockId] = block;
                    }
                }
            }
        }
    }
}
