using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ASP_NET.Pages
{
    [Authorize]
    public class EmployeeScheduleModel : PageModel
    {
        private IScheduleRepository scheduleRepository;
        private ITaskRepository taskRepository;
        private IScheduleManager scheduleManager;

        public DateOnly firstDayOfWeek;
        public Schedule[] schedule = new Schedule[7];
        public int weekNumber { get; set; }

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

            GetWeekSchedule();
        }

        public IActionResult OnPostPrevious()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber - 1).ToString());
            firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            Response.Cookies.Append("firstDayOfWeek", (firstDayOfWeek.AddDays(-7)).ToString());
            return RedirectToPage("EmployeeSchedule");
        }
        public IActionResult OnPostNext()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber + 1).ToString());
            firstDayOfWeek = DateOnly.Parse(Request.Cookies["firstDayOfWeek"]);
            Response.Cookies.Append("firstDayOfWeek", (firstDayOfWeek.AddDays(7)).ToString());
            return RedirectToPage("EmployeeSchedule");
        }
        public IActionResult OnPostNew()
        {
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
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = scheduleManager.GetDayScheduleEmployee(firstDayOfWeek.AddDays(i), 129);
            }
        }
    }
}
