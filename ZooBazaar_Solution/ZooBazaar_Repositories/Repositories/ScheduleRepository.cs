using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_Repositories.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi463992;User Id=dbi463992;Password=gogotpilon;";

        ScheduleDTO IScheduleRepository.GetByDateAndEmployeeId(DateOnly date, int employeeId)
        {
            ScheduleDTO scheduleDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Schedule WHERE Day = @Day AND Month = @Month AND Year = @Year AND EmployeeID = @EmployeeID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Day", date.Day);
                    command.Parameters.AddWithValue("@Month", date.Month);
                    command.Parameters.AddWithValue("@Year", date.Year);
                    command.Parameters.AddWithValue("@EmployeeID", employeeId);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int scheduleid = reader.GetInt32(0);
                        int day = reader.GetInt32(1);
                        int month = reader.GetInt32(2);
                        int year = reader.GetInt32(3);
                        int timeblockid = reader.GetInt32(4);
                        int employeeid = reader.GetInt32(5);
                        int taskid = reader.GetInt32(6);

                        scheduleDTO = new ScheduleDTO
                        {
                            Id = scheduleid,
                            Day = day,
                            Month = month,
                            Year = year,
                            TimeblockID = timeblockid,
                            EmployeeID = employeeid,
                            TaskID = taskid
                        };
                    }
                }
            }
            return scheduleDTO;
        }

        void IScheduleRepository.Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleID", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        IEnumerable<ScheduleDTO> IScheduleRepository.GetAll()
        {
            List<ScheduleDTO> scheduleDTOs = new List<ScheduleDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Schedule";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int scheduleid = reader.GetInt32(0);
                        int day = reader.GetInt32(1);
                        int month = reader.GetInt32(2);
                        int year = reader.GetInt32(3);
                        int timeblockid = reader.GetInt32(4);
                        int employeeid = reader.GetInt32(5);
                        int taskid = reader.GetInt32(6);

                        scheduleDTOs.Add(new ScheduleDTO
                        {
                            Id = scheduleid,
                            Day = day,
                            Month = month,
                            Year = year,
                            TimeblockID = timeblockid,
                            EmployeeID = employeeid,
                            TaskID = taskid
                        });
                    }
                }
            }
            return scheduleDTOs;
        }

        ScheduleDTO IScheduleRepository.GetByScheduleId(int ID)
        {
            ScheduleDTO scheduleDTO = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT * FROM Schedule WHERE ScheduleID = @ID";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int scheduleid = reader.GetInt32(0);
                        int day = reader.GetInt32(1);
                        int month = reader.GetInt32(2);
                        int year = reader.GetInt32(3);
                        int timeblockid = reader.GetInt32(4);
                        int employeeid = reader.GetInt32(5);
                        int taskid = reader.GetInt32(6);

                        scheduleDTO = new ScheduleDTO
                        {
                            Id = scheduleid,
                            Day = day,
                            Month = month,
                            Year = year,
                            TimeblockID = timeblockid,
                            EmployeeID = employeeid,
                            TaskID = taskid
                        };
                    }
                }
            }
            return scheduleDTO;
        }

        void IScheduleRepository.Insert(ScheduleDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "INSERT INTO Schedule VALUES (@Day,@Month,@Year,@TimeblockID,@EmployeeID,@TaskID)";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@Day", dto.Day);
                    command.Parameters.AddWithValue("@Month", dto.Month);
                    command.Parameters.AddWithValue("@Year", dto.Year);
                    command.Parameters.AddWithValue("@TimeblockID", dto.TimeblockID);
                    command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeID);
                    command.Parameters.AddWithValue("@TaskID", dto.TaskID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        int IScheduleRepository.nextID()
        {
            int newID = 1;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "SELECT MAX(ScheduleID) FROM Schedule";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            int id = reader.GetInt32(0);
                            newID = id + 1;
                        }
                    }
                }
            }
            return newID;
        }

        void IScheduleRepository.Update(ScheduleDTO dto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string Query = "UPDATE Schedule SET Day=@Day,Month=@Month,Year=@Year,TimeblockID=@TimeblockID,EmployeeID=@EmployeeID,TaskID=@TaskID WHERE ScheduleID=@ScheduleID";

                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddWithValue("@ScheduleID", dto.Id);
                    command.Parameters.AddWithValue("@Day", dto.Day);
                    command.Parameters.AddWithValue("@Month", dto.Month);
                    command.Parameters.AddWithValue("@Year", dto.Year);
                    command.Parameters.AddWithValue("@TimeblockID", dto.TimeblockID);
                    command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeID);
                    command.Parameters.AddWithValue("@TaskID", dto.TaskID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
