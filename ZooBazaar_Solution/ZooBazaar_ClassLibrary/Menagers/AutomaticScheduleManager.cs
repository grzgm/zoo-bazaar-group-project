using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using ZooBazaar_Repositories.Repositories;

namespace ZooBazaar_ClassLibrary.Menagers
{
	public class AutomaticScheduleManager : IAutomaticScheduleManager
    {
		private IScheduleRepository scheduleRepository;
		private ITaskRepository taskRepository;
		private IScheduleManager scheduleManager;
		private IStaticScheduleManager staticScheduleManager;
		private IStaticScheduleRepository staticScheduleRepository;
		private IEmployeeMenager employeeMenager;
		private IEmployeeRepositroty employeeRepositroty;
		private IUnavailabilityScheduleRepository unavailabilityScheduleRepository;
		private IUnavailabilityScheduleMenager unavailabilityScheduleMenager;

		public List<List<Schedule>> MakeSchedule(DateOnly firstDayOfWeek)
		{
			scheduleRepository = new ScheduleRepository();
			taskRepository = new TaskRepository();
			scheduleManager = new ScheduleManager(scheduleRepository, taskRepository);
			staticScheduleRepository = new StaticScheduleRepository();
			staticScheduleManager = new StaticScheduleManager(staticScheduleRepository);
			employeeRepositroty = new EmployeeRepository();
			employeeMenager = new EmployeeManager(employeeRepositroty);
			unavailabilityScheduleRepository = new UnavailabilityScheduleRepository();
			unavailabilityScheduleMenager = new UnavailabilityScheduleMenager(unavailabilityScheduleRepository);

			List<List<StaticSchedule>> weekStaticSchedule = new List<List<StaticSchedule>>();
			List<Employee> employees = new List<Employee>();

			employees = employeeMenager.GetAll();

			DateOnly addDate = firstDayOfWeek;
			for (int i = 1; i < 7; i++)
			{
				weekStaticSchedule.Add(staticScheduleManager.GetScheduleFromDay(i));
			}

			weekStaticSchedule.Add(staticScheduleManager.GetScheduleFromDay(0));

			foreach (List<StaticSchedule> dayStaticSchedule in weekStaticSchedule)
			{
				foreach (StaticSchedule staticSchedule in dayStaticSchedule)
				{
					int amountOfEmployeesAddedToTask = scheduleManager.AmountOfEmployessAssignedToTaskTimeBlockDate(addDate.Day, addDate.Month, addDate.Year, staticSchedule.TaskID, staticSchedule.timeBlockId);
					foreach (Employee employee in employees)
					{
						if (staticSchedule.EmployeesNeeded <= amountOfEmployeesAddedToTask)
						{
							break;
						}
						if (unavailabilityScheduleMenager.GetByEmployeeIDDayMonthYear(employee.ID, addDate.Day, addDate.Month, addDate.Year).Any())
						{
							continue;
						}
						List<Schedule> employeeDaySchedule = scheduleManager.GetDayScheduleEmployeeAllSchdules(addDate, employee.ID);
						if (employeeDaySchedule.Find(x => x.timeBlock.StartTime == staticSchedule.timeBlock.StartTime) != null)
						{
							continue;
						}
						if (employeeDaySchedule.Count >= 8)
						{
							continue;
						}

						ScheduleAddDTO scheduleAddDTO = new ScheduleAddDTO()
						{
							Day = addDate.Day,
							Month = addDate.Month,
							Year = addDate.Year,
							TimeblockID = staticSchedule.timeBlockId,
							EmployeeID = employee.ID,
							TaskID = staticSchedule.task.ID,
						};

						scheduleManager.Insert(scheduleAddDTO);
						amountOfEmployeesAddedToTask++;
					}
				}
				addDate = addDate.AddDays(1);
			}

			return null;
		}
	}
}
