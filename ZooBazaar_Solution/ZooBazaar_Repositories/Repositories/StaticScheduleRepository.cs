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
    public class StaticScheduleRepository : BaseRepository, IStaticScheduleRepository
    {
        private List<StaticScheduleDTO> GetStaticSchedule(string Query, List<SqlParameter>? sqlParameters)
        {
            List<StaticScheduleDTO> schedules = new List<StaticScheduleDTO>();
            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    connection.Open();
                    if (sqlParameters != null)
                    {
                        command.Parameters.AddRange(sqlParameters.ToArray());
                    }
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int staticscheduleid = reader.GetInt32(0);
                        int dayoftheweek = reader.GetInt32(1);
                        int employeesneeded = reader.GetInt32(4);
                        
                        int timeblockid = reader.GetInt32(5);
                        TimeSpan starttime = reader.GetTimeSpan(6);
                        TimeSpan endtime = reader.GetTimeSpan(7);

                        int taskid = reader.GetInt32(8);
                        string taskname = reader.GetString(9);

                        int habitatid = reader.GetInt32(13);
                        string habitatname = reader.GetString(14);
                        int habitatcapacity = reader.GetInt32(15);

                        int zoneid = reader.GetInt32(17);
                        string zonename = reader.GetString(18);
                        int zonecapacity = reader.GetInt32(19);

                        schedules.Add(new StaticScheduleDTO
                        {
                            ScheduleID = staticscheduleid,
                            DayOfWeek = dayoftheweek,
                            EmployeesNeeded = employeesneeded,
                            TimeBlockDTO = new TimeBlockDTO 
                            {
                                TimeblockID = timeblockid,
                                StartingTime = starttime,
                                EndingTime = endtime
                            },
                            TaskDTO = new TaskDTO
                            {
                                TaskID = taskid,
                                Name = taskname,
                                HabitatDTO = new HabitatDTO
                                {
                                    HabitatID = habitatid,
                                    Name = habitatname,
                                    Capacity = habitatcapacity,
                                    ZoneDTO = new ZoneDTO
                                    {
                                        ZoneID = zoneid,
                                        Name = zonename,
                                        Capacity = zonecapacity
                                    }
                                }
                            }
                        });
                    }
                    connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return schedules;
        }
        public void AddSchedule(StaticScheduleAddDTO staticScheduleAddDTO)
        {
            string Query = "INSERT INTO StaticSchedule Values(@DayOfTheWeek,@TimeblockID,@TaskID,@EmployeesNeeded)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@DayOfTheWeek", staticScheduleAddDTO.DayOfTheWeek));
                sqlParameters.Add(new SqlParameter("@TimeblockID", staticScheduleAddDTO.TimeBlockID));
                sqlParameters.Add(new SqlParameter("@TaskID", staticScheduleAddDTO.TaskID));
                sqlParameters.Add(new SqlParameter("@EmployeesNeeded", staticScheduleAddDTO.EmployeesNeeded));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<StaticScheduleDTO> GetScheduleFromDay(int day)
        {
            string Query = "SELECT * FROM StaticSchedule S JOIN Timeblock T ON S.TimeblockID=T.TimeblockID JOIN TASK TK ON S.TaskID=TK.TaskID JOIN Habitat H ON TK.HabitatID=H.HabitatID JOIN Zone Z ON Z.ZoneID=TK.ZoneID WHERE DayOfTheWeek=@DayOfTheWeek";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@DayOfTheWeek", day));
                return GetStaticSchedule(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void RemoveSchedule(int scheduleid)
        {
            string Query = "DELETE FROM StaticSchedule WHERE StaticScheduleID=@ScheduleID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@ScheduleID", scheduleid));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void UpdateEmployeesNeeded(int scheduleid, int employeesNeeded)
        {
            string Query = "UPDATE StaticSchedule SET EmployeesNeeded=@EmployeesNeeded WHERE StaticScheduleID=@ScheduleID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@ScheduleID", scheduleid));
                sqlParameters.Add(new SqlParameter("@EmployeesNeeded", employeesNeeded));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DeleteExistingSchedules(int taskid)
        {
            string Query = "DELETE FROM Schedule WHERE TaskID=@TaskID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@TaskID", taskid));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
