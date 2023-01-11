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
                        
                        int timeblockid = reader.GetInt32(4);
                        TimeSpan starttime = reader.GetTimeSpan(5);
                        TimeSpan endtime = reader.GetTimeSpan(6);

                        int taskid = reader.GetInt32(7);
                        string taskname = reader.GetString(8);

                        int habitatid = reader.GetInt32(12);
                        string habitatname = reader.GetString(13);
                        int habitatcapacity = reader.GetInt32(14);

                        int zoneid = reader.GetInt32(16);
                        string zonename = reader.GetString(17);
                        int zonecapacity = reader.GetInt32(18);

                        schedules.Add(new StaticScheduleDTO
                        {
                            ScheduleID = staticscheduleid,
                            DayOfWeek = dayoftheweek,
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
            string Query = "INSERT INTO StaticSchedule Values(@DayOfTheWeek,@TimeblockID,@TaskID)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@DayOfTheWeek", staticScheduleAddDTO.DayOfTheWeek));
                sqlParameters.Add(new SqlParameter("@TimeblockID", staticScheduleAddDTO.TimeBlockID));
                sqlParameters.Add(new SqlParameter("@TaskID", staticScheduleAddDTO.TaskID));
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
    }
}
