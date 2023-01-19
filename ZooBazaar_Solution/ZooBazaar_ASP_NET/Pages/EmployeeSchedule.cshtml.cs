using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class EmployeeScheduleModel : PageModel
    {
        private IScheduleRepository scheduleRepository;
        private ITaskRepository taskRepository;
        private IScheduleManager scheduleManager;

        public DateOnly firstDayOfWeek;
        public int closingHour = 22;
        public int startingHour = 6;
        public Schedule[][] schedule;
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

            schedule = new Schedule[7][];
            for (int i = 0; i < 7; i++)
            {
                schedule[i] = new Schedule[24];
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
        public IActionResult OnPostToday()
        {
            Response.Cookies.Delete("weekNumber");
            Response.Cookies.Delete("firstDayOfWeek");
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
                if(scheduleList.Count > 0)
                {
                    foreach (Schedule block in scheduleList)
                    {
                        schedule[i][block.timeBlockId] = block;
                    }
                }
            }
        }

        public IActionResult OnGetInformationAboutTask(int i, int j)
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
            for (int k = 0; k < 7; k++)
            {
                schedule[k] = new Schedule[24];
            }
            GetWeekSchedule();

            if (schedule[i][j].task.animal != null)
            {
                return new JsonResult(new
                {
                    TaskName = schedule[i][j].taskName,
                    TaskHabitat = schedule[i][j].taskHabitat,
                    TaskZone = schedule[i][j].taskZone,
                    date = schedule[i][j].date.ToString(),
                    startTime = schedule[i][j].timeBlock.StartTime.ToString(),
                    endTime = schedule[i][j].timeBlock.EndTime.ToString(),
                    HaveAnimal = true,
                    animalName = schedule[i][j].task.animal.Name,
                    animalDiet = schedule[i][j].task.animal.Diet,
                    animalAge = schedule[i][j].task.animal.Age,
                    animalFeedingInterval = schedule[i][j].task.animal.FeedingInterval,
                    animalGender = schedule[i][j].task.animal.Sex,
                    animalSpecialCare = schedule[i][j].task.animal.SpecialCare,
                    animalSpecies = schedule[i][j].task.animal.Species,
                    animalSpeciesType = schedule[i][j].task.animal.SpeciesType,
                   
                }); ;

            }
            else
            {
                return new JsonResult(new
                {
                    TaskName = schedule[i][j].taskName,
                    TaskHabitat = schedule[i][j].taskHabitat,
                    TaskZone = schedule[i][j].taskZone,
                    date = schedule[i][j].date.ToString(),
                    startTime = schedule[i][j].timeBlock.StartTime.ToString(),
                    endTime = schedule[i][j].timeBlock.EndTime.ToString(),
                    HaveAnimal = false,
                }); ;
            }




            
        }


    }
}
