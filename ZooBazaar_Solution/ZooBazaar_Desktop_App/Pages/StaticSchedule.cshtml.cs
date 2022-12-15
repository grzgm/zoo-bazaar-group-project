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
        public int weekNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public int day { get; set; }

        public int month { get; set; }

        public int year { get; set; }

        public StaticScheduleModel()
        {
            scheduleRepository = new ScheduleRepository();
            taskRepository = new TaskRepository();
            scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);
        }

        public void OnGet()
        {
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

        public void OnGetPrevious()
        {
            DayOfWeek dayOfWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(day);
            if (dayOfWeek >= DayOfWeek.Monday && dayOfWeek <= DayOfWeek.Wednesday)
            {
                day = day.AddDays(3);
            }
            weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(todayOfWeek, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            firstDayOfWeek = FirstDayOfWeek(DateOnly.FromDateTime(DateTime.Now));

            schedule = new Schedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new Schedule[24];
            }
            GetWeekSchedule();
        }
        public IActionResult OnPostToday()
        {
            Response.Cookies.Delete("weekNumber");
            Response.Cookies.Delete("firstDayOfWeek");
            return RedirectToPage("StaticSchedule");
        }
        public IActionResult OnPostNext()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber + 1).ToString());
            firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            Response.Cookies.Append("firstDayOfWeek", (firstDayOfWeek.AddDays(7)).ToString());
            return RedirectToPage("StaticSchedule");
        }
        public void DateCorrection()
        {
            if(day < 1)
            {
                month -= 1;
                if (month > 12)
                {
                    year += 1;
                    month = 1;
                }
                else if (month < 1)
                {
                    year -= 1;
                    month = 12;
                }
            }
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
            IUnavailabilityScheduleRepository unavailabilityScheduleRepository;
            IUnavailabilityScheduleMenager unavailabilityScheduleMenager;
            unavailabilityScheduleRepository = new UnavailabilityScheduleRepository();
            unavailabilityScheduleMenager = new UnavailabilityScheduleMenager(unavailabilityScheduleRepository);


            unavailabilityScheduleMenager.AddUnSchedule(new UnavailabilityScheduleDTO { Date = new DateTime(year, month, day), EmployeeID = employeeId });

            unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
            amountOfUnavailableDays += 1;

            return RedirectToPage("StaticSchedule");
        }
        public IActionResult OnPostDelete()
        {
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
