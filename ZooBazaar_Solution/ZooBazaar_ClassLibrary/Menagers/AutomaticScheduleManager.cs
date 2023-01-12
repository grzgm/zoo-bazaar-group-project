using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ClassLibrary.Menagers
{
	public class AutomaticScheduleManager
	{
		private IScheduleRepository scheduleRepository;
		private ITaskRepository taskRepository;
		private IScheduleManager scheduleManager;
		private IEmployeeMenager employeeMenager;
		private IEmployeeRepositroty employeeRepositroty;
		private IUnavailabilityScheduleRepository unavailabilityScheduleRepository;
		private IUnavailabilityScheduleMenager unavailabilityScheduleMenager;

		public List<List<Schedule>> MakeSchedule(DateOnly firstDayOfWeek)
		{
			scheduleRepository = new ScheduleRepository();
			taskRepository = new TaskRepository();
			scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);
			employeeRepositroty = new EmployeeRepository();
			employeeMenager = new EmployeeManager(employeeRepositroty);
			unavailabilityScheduleRepository = new UnavailabilityScheduleRepository();
			unavailabilityScheduleMenager = new UnavailabilityScheduleMenager(unavailabilityScheduleRepository);

			List<List<Schedule>> weekStaticSchedule = new List<List<Schedule>>();
			List<Employee> employees = new List<Employee>();

			employees = employeeMenager.GetAll();

			DateOnly date = new DateOnly(2022, 12, 12);
			for (int i = 0; i < 7; i++)
			{
				weekStaticSchedule.Add(scheduleManager.GetDayScheduleEmployeeAllSchdules(date.AddDays(i), 2));
			}

			foreach (List<Schedule> dayStaticSchedule in weekStaticSchedule)
			{
				foreach (Schedule staticSchedule in dayStaticSchedule)
				{
					foreach (Employee employee in employees)
					{
						if (unavailabilityScheduleMenager.GetByEmployeeIDDayMonthYear(employee.ID, staticSchedule.date.Day, staticSchedule.date.Month, staticSchedule.date.Year).Any())
						{
							continue;
						}
						List<Schedule> employeeDaySchedule = scheduleManager.GetDayScheduleEmployeeAllSchdules(staticSchedule.date, employee.ID);
						if (employeeDaySchedule.Find(x => x.timeBlock.StartTime == staticSchedule.timeBlock.StartTime) != null)
						{
							continue;
						}
						if(employeeDaySchedule.Count >= 8)
						{
							continue;
						}

						ScheduleAddDTO scheduleAddDTO = new ScheduleAddDTO()
						{
							Day = staticSchedule.date.Day,
							Month = staticSchedule.date.Month,
							Year = staticSchedule.date.Year,
							TimeblockID = staticSchedule.timeBlockId,
							EmployeeID = employee.ID,
							TaskID = staticSchedule.task.id,
						};

						scheduleManager.Insert(scheduleAddDTO);
					}
				}
			}

			return null;
		}
	}
}
