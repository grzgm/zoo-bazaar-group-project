using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ASP_NET.Pages
{
    public class UnavailabilityScheduleModel : PageModel
    {
        private IScheduleRepository scheduleRepository;
        private ITaskRepository taskRepository;
        private IScheduleManager scheduleManager;

        public DateOnly firstDayOfWeek;
        public int openDuration = 16;
        public Schedule[][] schedule;
        public int weekNumber { get; set; }

        [BindProperty(SupportsGet = true)]
        public int create { get; set; }
        [BindProperty(SupportsGet = true)]
        public int delete { get; set; }
        public void OnGet()
        {
            scheduleRepository = new ScheduleRepository();
            taskRepository = new TaskRepository();
            scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);

            if (!Request.Cookies.ContainsKey("weekNumber"))
            {
                DateTime today = DateTime.Now;
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(today);
                if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                {
                    today = today.AddDays(3);
                }
                weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                Response.Cookies.Append("weekNumber", weekNumber.ToString());
                firstDayOfWeek = FirstDayOfWeek(DateOnly.FromDateTime(DateTime.Now));
                Response.Cookies.Append("firstDayOfWeek", firstDayOfWeek.ToString());
            }
            else
            {
                weekNumber = int.Parse(Request.Cookies["weekNumber"]);
                firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            }

            schedule = new Schedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new Schedule[openDuration];
            }
            GetWeekSchedule();
        }

        public IActionResult OnPostPrevious()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber - 1).ToString());
            firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            Response.Cookies.Append("firstDayOfWeek", (firstDayOfWeek.AddDays(-7)).ToString());
            return RedirectToPage("UnavailabilitySchedule");
        }
        public IActionResult OnPostToday()
        {
            Response.Cookies.Delete("weekNumber");
            Response.Cookies.Delete("firstDayOfWeek");
            return RedirectToPage("UnavailabilitySchedule");
        }
        public IActionResult OnPostNext()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber + 1).ToString());
            firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            Response.Cookies.Append("firstDayOfWeek", (firstDayOfWeek.AddDays(7)).ToString());
            return RedirectToPage("UnavailabilitySchedule");
        }
        public IActionResult OnPostNew()
        {
            return OnPostToday();
            return Page();
        }
        private DateOnly FirstDayOfWeek(DateOnly dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff);
        }

        private void GetWeekSchedule()
        {
            List<Schedule> scheduleList = new List<Schedule>();
            for (int i = 0; i < 7; i++)
            {
                scheduleList = scheduleManager.GetDayScheduleEmployeeAllSchdules(firstDayOfWeek.AddDays(i), int.Parse(User.FindFirstValue("Id")));
                if (scheduleList.Count > 0)
                {
                    foreach (Schedule block in scheduleList)
                    {
                        schedule[i][block.timeBlockId] = block;
                    }
                }
            }
        }
        public IActionResult OnPostCreate()
        {
            int a = create;
            return OnPostToday();
            return Page();
        }
        public IActionResult OnPostDelete()
        {
            int a = delete;
            return OnPostToday();
            return Page();
        }
    }
}
