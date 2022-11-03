// See https://aka.ms/new-console-template for more information
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Repositories;
using System.Configuration;



Console.WriteLine("Hello, World!");

ScheduleRepository repository = new ScheduleRepository();

List<Schedule> schedules = new List<Schedule>();    

foreach (ScheduleDTO dto in repository.GetByDateAndEmployeeId(new DateOnly(2020, 11, 19), 80)){
    schedules.Add(new Schedule(dto));
}
foreach(Schedule s in schedules)
{
    Console.WriteLine(s.taskName, s.timeBlockId);
}