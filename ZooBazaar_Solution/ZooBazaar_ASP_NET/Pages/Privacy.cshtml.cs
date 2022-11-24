using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace ZooBazaar_ASP_NET.Pages
{
    public class PrivacyModel : PageModel
    {

        public CalendarGenerator _generator { get; set; }


        public PrivacyModel()
        {
            _generator = new CalendarGenerator();
            _generator.GenerateCalendar(2022, 11);
        }

        public void OnGet()
        {
        }
    }

    public class CalendarGenerator
    {
        public struct DisplayDay
        {
            public int Day { get; set; }
            public string MoodValue { get; set; }
        }


        public DisplayDay[] days { get; set; }
        public CalendarGenerator()
        {
            days = new DisplayDay[42];
        }

        public void GenerateCalendar(int year, int month)
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;

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
                displsayDays[i].MoodValue = "Empty";
                counterOfDaysInCurrentMonth++;
            }
            int counterDaysOfNextMonth = 1;
            for (int j = AmountOfDaysInMonth + position; j < 42; j++)
            {
                displsayDays[j].Day = counterDaysOfNextMonth;
                displsayDays[j].MoodValue = "NotActive";
                counterDaysOfNextMonth++;
            }
            if (position > 0)
            {
                int amountOfDaysInMonthCounter = DateTime.DaysInMonth(year, month - 1);
                for (int k = position - 1; k >= 0; k--)
                {
                    displsayDays[k].Day = amountOfDaysInMonthCounter;
                    displsayDays[k].MoodValue = "NotActive";
                    amountOfDaysInMonthCounter--;
                }
            }

            days = displsayDays;

            foreach (var d in days)
            {

                Console.WriteLine(d.Day + " " + d.MoodValue);
            }

        }
    }
}