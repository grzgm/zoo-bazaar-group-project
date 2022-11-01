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
    public class EmployeeScheduleModel : PageModel
    {
        private IScheduleRepository scheduleRepository;
        private ITaskRepository taskRepository;
        private IScheduleManager scheduleManager;
        public Schedule schedule;

        [BindProperty(SupportsGet = true)]
        [ViewData]
        public int weekNumber { get; set; }

        public void OnGet()
        {
            scheduleRepository = new ScheduleRepository();
            taskRepository = new TaskRepository();
            scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);

            schedule = scheduleManager.GetDayScheduleEmployee(new DateOnly(2022, 10, 1), 129);

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
            }
            else
            {
                weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            }
        }

        public IActionResult OnPostPrevious()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber - 1).ToString());
            return RedirectToPage("EmployeeSchedule");
        }
        public IActionResult OnPostNext()
        {
            weekNumber = int.Parse(Request.Cookies["weekNumber"]);
            Response.Cookies.Append("weekNumber", (weekNumber + 1).ToString());
            return RedirectToPage("EmployeeSchedule");
        }
        public IActionResult OnPostNew()
        {
            return Page();
        }
    }
}
