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
using static System.Net.Mime.MediaTypeNames;

namespace ZooBazaar_ASP_NET.Pages
{
    [Authorize]
    public class UnavailabilityScheduleModel : PageModel
    {
        private IUnavailabilityScheduleRepository unavailabilityScheduleRepository;
        private IUnavailabilityScheduleMenager unavailabilityScheduleMenager;

        [BindProperty(SupportsGet = true)]
        public int day { get; set; }

        [BindProperty(SupportsGet = true)]
        public int month { get; set; }

        [BindProperty(SupportsGet = true)]
        public int year { get; set; }
        public int employeeId { get; set; }

        public int amountOfUnavailableDays { get; set; }
        public int maxAmountOfUnavailableDays { get; set; }
        public CalendarGenerator _generator { get; set; }

        public List<UnavailabilityScheduleDTO> unavailabilityList;
        public UnavailabilityScheduleModel()
        {
            _generator = new CalendarGenerator();
            unavailabilityScheduleRepository = new UnavailabilityScheduleRepository();
            unavailabilityScheduleMenager = new UnavailabilityScheduleMenager(unavailabilityScheduleRepository);
        }
        public void OnGet()
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            SettingUpPage();
        }

        public IActionResult OnPostPrevious()
        {
            DateCorrection();
            SettingUpPage();
            return Page();
        }
        public IActionResult OnPostToday()
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            SettingUpPage();
            return Page();
        }
        public IActionResult OnPostNext()
        {
            DateCorrection();
            SettingUpPage();
            return Page();
        }
        public IActionResult OnPostCreate()
        {
            SettingUpPage();
            if (maxAmountOfUnavailableDays > amountOfUnavailableDays)
                unavailabilityScheduleMenager.AddUnSchedule(new UnavailabilityScheduleDTO { Date = new DateTime(year, month, day), EmployeeID = employeeId });

            unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
            amountOfUnavailableDays += 1;

            return Page();
        }
        public IActionResult OnPostDelete()
        {
            SettingUpPage();
            unavailabilityScheduleMenager.DeleteUnSchedule(new UnavailabilityScheduleDTO { Date = new DateTime(year, month, day), EmployeeID = employeeId });

            unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
            if (amountOfUnavailableDays > 0)
                amountOfUnavailableDays -= 1;

            return Page();
        }

        //public IActionResult OnPostCreate()
        //{
        //    employeeId = int.Parse(User.FindFirstValue("Id"));
        //    _generator.GenerateCalendar(year, month);
        //    unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
        //    unavailabilityScheduleMenager.AddUnSchedule(new UnavailabilityScheduleDTO { Date = new DateTime(year, month, day), EmployeeID = employeeId });
        //    unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
        //    return Page();
        //}
        //public IActionResult OnPostDelete()
        //{
        //    SettingUpPage();
        //    unavailabilityScheduleMenager.DeleteUnSchedule(new UnavailabilityScheduleDTO { Date = new DateTime(year, month, day), EmployeeID = employeeId });
        //    unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
        //    return Page();
        //}

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

        public void SettingUpPage()
        {
            // cannot access User in the constructor IDK why???
            employeeId = int.Parse(User.FindFirstValue("Id"));
            _generator.GenerateCalendar(year, month);
            unavailabilityList = unavailabilityScheduleMenager.GetByEmployeeIDMonthYear(employeeId, month, year).ToList();
            maxAmountOfUnavailableDays = 17;
            amountOfUnavailableDays = unavailabilityList.Count();
        }

        public bool IsTwoWeek(CalendarGenerator.DisplayDay date)
        {
            DateTime twoweekDate = DateTime.Now.AddDays(14);
            DateTime selectedDate = new DateTime(twoweekDate.Year, date.Month, date.Day);
            if (selectedDate < twoweekDate)
            {
                return true;
            }
            return false;
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
                if (month == 1)
                    amountOfDaysInMonthCounter = DateTime.DaysInMonth(year - 1, 12);
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
