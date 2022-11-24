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
    [Authorize]
    public class UnavailabilityScheduleModel : PageModel
    {
        private IUnavailabilityScheduleRepository unavailabilityScheduleRepository;
        private IUnavailabilityScheduleMenager unavailabilityScheduleMenager;

        [BindProperty(SupportsGet = true)]
        public int create { get; set; }

        [BindProperty(SupportsGet = true)]
        public int delete { get; set; }

        [BindProperty(SupportsGet = true)]
        public int month { get; set; }

        [BindProperty(SupportsGet = true)]
        public int year { get; set; }
        public int employeeId { get; set; }
        public CalendarGenerator _generator { get; set; }

        public List<UnavailabilityScheduleDTO> unavailabilityList;
        public UnavailabilityScheduleModel()
        {
            _generator = new CalendarGenerator();
            unavailabilityScheduleRepository = new UnavailabilityScheduleRepository();
            unavailabilityScheduleMenager = new UnavailabilityScheduleMenager(unavailabilityScheduleRepository);

            //employeeId = int.Parse(User.FindFirstValue("Id"));
            employeeId = 22;

            unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
        }
        public void OnGet()
        {
            year = DateTime.Now.Year;
            month= DateTime.Now.Month;
            _generator.GenerateCalendar(year, month);
        }

        public IActionResult OnPostPrevious()
        {
            DateCorrection();
            _generator.GenerateCalendar(year, month);
            return Page();
        }
        public IActionResult OnPostToday()
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            _generator.GenerateCalendar(year, month);
            return Page();
        }
        public IActionResult OnPostNext()
        {
            DateCorrection();
            _generator.GenerateCalendar(year, month);
            return Page();
        }
        public IActionResult OnPostCreate()
        {
            unavailabilityScheduleMenager.AddUnSchedule(new UnavailabilityScheduleAddDTO { Date = new DateTime(year,month,create), EmployeeID= employeeId });
            return OnPostToday();
            return Page();
        }
        public IActionResult OnPostDelete()
        {
            //unavailabilityScheduleMenager.DeleteUnSchedule(new UnavailabilityScheduleAddDTO { Date = new DateTime(year, month, create), EmployeeID = employeeId });
            unavailabilityScheduleMenager.DeleteUnSchedule(1);
            return OnPostToday();
            return Page();
        }

        public void DateCorrection()
        {
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

    public class CalendarGenerator
    {
        public struct DisplayDay
        {
            public int Day { get; set; }
            public int Month { get; set; }
        }


        public DisplayDay[] days { get; set; }
        public CalendarGenerator()
        {
            days = new DisplayDay[42];
        }

        public void GenerateCalendar(int year, int month)
        {
            //year = DateTime.Now.Year;
            //month = DateTime.Now.Month;

            DisplayDay[] displsayDays = new DisplayDay[42];
            int AmountOfDaysInMonth = DateTime.DaysInMonth(year, month);
            DateOnly firstDayOfMonth = new DateOnly(year, month, 01);
            int position = 0;

            switch (firstDayOfMonth.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    position = 0;
                    break;
                case DayOfWeek.Tuesday:
                    position = 1;
                    break;
                case DayOfWeek.Wednesday:
                    position = 2;
                    break;
                case DayOfWeek.Thursday:
                    position = 3;
                    break;
                case DayOfWeek.Friday:
                    position = 4;
                    break;
                case DayOfWeek.Saturday:
                    position = 5;
                    break;
                case DayOfWeek.Sunday:
                    position = 6;
                    break;
            }

            int counterOfDaysInCurrentMonth = 1;
            for (int i = position; i < AmountOfDaysInMonth + position; i++)
            {
                displsayDays[i].Day = counterOfDaysInCurrentMonth;
                displsayDays[i].Month = month;
                counterOfDaysInCurrentMonth++;
            }
            int counterDaysOfNextMonth = 1;
            for (int j = AmountOfDaysInMonth + position; j < 42; j++)
            {
                displsayDays[j].Day = counterDaysOfNextMonth;
                displsayDays[j].Month = -1;
                counterDaysOfNextMonth++;
            }
            if (position > 0)
            {
                // WHY
                int amountOfDaysInMonthCounter;
                if (month== 1)
                    amountOfDaysInMonthCounter = DateTime.DaysInMonth(year-1, 12);
                else
                    amountOfDaysInMonthCounter = DateTime.DaysInMonth(year, month - 1);
                for (int k = position - 1; k >= 0; k--)
                {
                    displsayDays[k].Day = amountOfDaysInMonthCounter;
                    displsayDays[k].Month = -1;
                    amountOfDaysInMonthCounter--;
                }
            }

            days = displsayDays;
        }
    }

}
