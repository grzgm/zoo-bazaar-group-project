using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;
using System.Diagnostics;
using System.Collections;
using System.Xml.Linq;


namespace ZooBazaar_Repositories.Repositories
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private IEnumerable<ScheduleDTO> GetSchedules(string Query, List<SqlParameter>? sqlParameters)
        {
            
            List<ScheduleDTO> schedules = new List<ScheduleDTO>();
            Dictionary<int, TimeBlockDTO> timeblocks = new Dictionary<int, TimeBlockDTO>();
            Dictionary<int, EmployeeDTO> employees = new Dictionary<int, EmployeeDTO>();
            Dictionary<int, TaskDTO> tasks = new Dictionary<int, TaskDTO>();
            Dictionary<int, AnimalDTO> animals = new Dictionary<int, AnimalDTO>();
            Dictionary<int, HabitatDTO> habitats = new Dictionary<int, HabitatDTO>();
            Dictionary<int, ZoneDTO> zones = new Dictionary<int, ZoneDTO>();

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
                        int scheduleid = reader.GetInt32(0);
                        int day = reader.GetInt32(1);
                        int month = reader.GetInt32(2);
                        int year = reader.GetInt32(3);

                        int schtimeblockid = reader.GetInt32(4);
                        if (!timeblocks.ContainsKey(schtimeblockid))
                        {
                            TimeSpan schstartingtime = reader.GetTimeSpan(5);
                            TimeSpan schendingtime = reader.GetTimeSpan(6);
                            TimeBlockDTO newtimeblock = new TimeBlockDTO { TimeblockID = schtimeblockid, StartingTime = schstartingtime, EndingTime = schendingtime };

                            timeblocks.Add(schtimeblockid, newtimeblock);
                        }

                        int employeeid = reader.GetInt32(7);
                        if (!employees.ContainsKey(employeeid))
                        {
                            string empfirstname = reader.GetString(8);
                            string emplastname = reader.GetString(9);
                            string empemail = reader.GetString(10);
                            string empphone = reader.GetString(11);
                            string empaddress = reader.GetString(12);
                            string emprole = reader.GetString(13);
                            string emppassword = reader.GetString(14);
                            int empunavailabilitydays = reader.GetInt32(15);

                            EmployeeDTO newemployee = new EmployeeDTO
                            {
                                EmployeeID = employeeid,
                                FirstName = empfirstname,
                                LastName = emplastname,
                                Email = empemail,
                                Phone = empphone,
                                Address = empaddress,
                                Role = emprole,
                                Password = emppassword,
                                UnavailabilityDays = empunavailabilitydays
                            };
                            employees.Add(employeeid, newemployee);
                        }

                        int taskid = reader.GetInt32(16);
                        int? animalid = null;
                        if (!reader.IsDBNull(18))
                        {
                            animalid = reader.GetInt32(18);
                        }
                        int habitatid = reader.GetInt32(31);
                        int zoneid = reader.GetInt32(34);


                        if (!tasks.ContainsKey(taskid))
                        {
                            string taskname = reader.GetString(17);

                            if(animalid == null)
                            {
                                if (!habitats.ContainsKey(habitatid))
                                {
                                    string habitatname = reader.GetString(32);
                                    int habitatcapacity = reader.GetInt32(33);

                                    if (!zones.ContainsKey(zoneid))
                                    {
                                        string zonename = reader.GetString(35);
                                        int zonecapacity = reader.GetInt32(36);

                                        ZoneDTO newzone = new ZoneDTO
                                        {
                                            ZoneID = zoneid,
                                            Name = zonename,
                                            Capacity = zonecapacity
                                        };
                                        zones.Add(zoneid, newzone);
                                    }

                                    HabitatDTO newhabitat = new HabitatDTO
                                    {
                                        HabitatID = habitatid,
                                        Name = habitatname,
                                        Capacity = habitatcapacity,
                                        ZoneDTO = zones[zoneid]
                                    };
                                    habitats.Add(habitatid, newhabitat);
                                }

                                TaskDTO taskwoanimal = new TaskDTO
                                {
                                    TaskID = taskid,
                                    Name = taskname,
                                    HabitatDTO = habitats[habitatid]
                                };
                                tasks.Add(taskid, taskwoanimal);
                            }
                            else if (animalid != null)
                            {
                                int animalidnotnull = Convert.ToInt32(animalid);
                                if (!animals.ContainsKey(animalidnotnull))
                                {
                                    string animalname = reader.GetString(19);
                                    int animalage = reader.GetInt32(20);
                                    DateTime animaldateofbirth = reader.GetDateTime(21);
                                    bool animalsex = reader.GetBoolean(22);
                                    string animalspecies = reader.GetString(23);
                                    string animalspeciestype = reader.GetString(24);
                                    string animaldiet = reader.GetString(25);
                                    int animalfeedinginterval = reader.GetInt32(29);
                                    string animalspecialcare = reader.GetString(30);
                                    int animalfeedingtimeid = reader.GetInt32(26);

                                    if (!habitats.ContainsKey(habitatid))
                                    {
                                        string habitatname = reader.GetString(32);
                                        int habitatcapacity = reader.GetInt32(33);

                                        if (!zones.ContainsKey(zoneid))
                                        {
                                            string zonename = reader.GetString(35);
                                            int zonecapacity = reader.GetInt32(36);

                                            ZoneDTO newzone = new ZoneDTO
                                            {
                                                ZoneID = zoneid,
                                                Name = zonename,
                                                Capacity = zonecapacity
                                            };
                                            zones.Add(zoneid, newzone);
                                        }

                                        HabitatDTO newhabitat = new HabitatDTO
                                        {
                                            HabitatID = habitatid,
                                            Name = habitatname,
                                            Capacity = habitatcapacity,
                                            ZoneDTO = zones[zoneid]
                                        };
                                        habitats.Add(habitatid, newhabitat);
                                    }

                                    if (!timeblocks.ContainsKey(animalfeedingtimeid))
                                    {
                                        TimeSpan animalstartingtime = reader.GetTimeSpan(27);
                                        TimeSpan animalendingtime = reader.GetTimeSpan(28);

                                        TimeBlockDTO newtimeblock = new TimeBlockDTO
                                        {
                                            TimeblockID = animalfeedingtimeid,
                                            StartingTime = animalstartingtime,
                                            EndingTime = animalendingtime
                                        };
                                        timeblocks.Add(animalfeedingtimeid, newtimeblock);
                                    }

                                    AnimalDTO newanimal = new AnimalDTO
                                    {
                                        AnimalId = animalidnotnull,
                                        Name = animalname,
                                        Age = animalage,
                                        DateOfBirth = animaldateofbirth,
                                        Sex = animalsex,
                                        Species = animalspecies,
                                        SpeciesType = animalspeciestype,
                                        Diet = animaldiet,
                                        FeedingInterval = animalfeedinginterval,
                                        TimeBlockDTO = timeblocks[animalfeedingtimeid],
                                        HabitatDTO = habitats[habitatid],
                                        SpecialCare = animalspecialcare
                                    };
                                    animals.Add(animalidnotnull, newanimal);

                                }

                                TaskDTO newtask = new TaskDTO
                                {
                                    TaskID = taskid,
                                    Name = taskname,
                                    AnimalDTO = animals[animalidnotnull],
                                    HabitatDTO = habitats[habitatid]
                                };
                                tasks.Add(taskid, newtask);
                            }
                        }

                        schedules.Add(new ScheduleDTO
                        {
                            ScheduleID = scheduleid,
                            Day = day,
                            Month = month,
                            Year = year,
                            TimeBlockDTO = timeblocks[schtimeblockid],
                            EmployeeDTO = employees[employeeid],
                            TaskDTO = tasks[taskid]
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

        ScheduleDTO IScheduleRepository.GetByDateAndEmployeeId(DateOnly date, int employeeId)
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE Day = @Day AND Month = @Month AND Year = @Year AND S.EmployeeID = @EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Day", date.Day));
                sqlParameters.Add(new SqlParameter("@Month", date.Month));
                sqlParameters.Add(new SqlParameter("@Year", date.Year));
                sqlParameters.Add(new SqlParameter("@EmployeeID", employeeId));
                return GetSchedules(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IScheduleRepository.Delete(int id)
        {
            string Query = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ScheduleID", id));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<ScheduleDTO> IScheduleRepository.GetAll()
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            return GetSchedules(Query, null);
        }
        ScheduleDTO IScheduleRepository.GetByScheduleId(int ID)
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE ScheduleID = @ID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ID", ID));
                return GetSchedules(Query, sqlParameters).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IScheduleRepository.Insert(ScheduleAddDTO dto)
        {
            string Query = "INSERT INTO Schedule VALUES (@Day,@Month,@Year,@TimeblockID,@EmployeeID,@TaskID)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Day", dto.Day));
                sqlParameters.Add(new SqlParameter("@Month", dto.Month));
                sqlParameters.Add(new SqlParameter("@Year", dto.Year));
                sqlParameters.Add(new SqlParameter("@TimeblockID", dto.TimeblockID));
                sqlParameters.Add(new SqlParameter("@EmployeeID", dto.EmployeeID));
                sqlParameters.Add(new SqlParameter("@TaskID", dto.TaskID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        int IScheduleRepository.nextID()
        {
            string Query = "SELECT MAX(ScheduleID) FROM Schedule";
            return ExecuteNextID(Query);
        }

        void IScheduleRepository.Update(ScheduleDTO dto)
        {
            string Query = "UPDATE Schedule SET Day=@Day,Month=@Month,Year=@Year,TimeblockID=@TimeblockID,EmployeeID=@EmployeeID,TaskID=@TaskID WHERE ScheduleID=@ScheduleID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@ScheduleID", dto.ScheduleID));
                sqlParameters.Add(new SqlParameter("@Day", dto.Day));
                sqlParameters.Add(new SqlParameter("@Month", dto.Month));
                sqlParameters.Add(new SqlParameter("@Year", dto.Year));
                sqlParameters.Add(new SqlParameter("@TimeblockID", dto.TimeBlockDTO.TimeblockID));
                sqlParameters.Add(new SqlParameter("@EmployeeID", dto.EmployeeDTO.EmployeeID));
                sqlParameters.Add(new SqlParameter("@TaskID", dto.TaskDTO.TaskID));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<ScheduleDTO> GetByDate(DateOnly date)
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE Day = @Day AND Month = @Month AND Year = @Year";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Day", date.Day));
                sqlParameters.Add(new SqlParameter("@Month", date.Month));
                sqlParameters.Add(new SqlParameter("@Year", date.Year));
                return GetSchedules(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<ScheduleDTO> GetByEmployeeId(int employeeId)
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE S.EmployeeID = @EmployeeID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", employeeId));
                return GetSchedules(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<ScheduleDTO> GetByAnimalId(int animalId)
        {
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE T.AnimalID = @AnimalID";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@AnimalID", animalId));
                return GetSchedules(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public IEnumerable<ScheduleDTO> GetByDateAndEmployeeIdAllSchdules(DateOnly date, int employeeId)
        {

            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, E.Password, E.UnavailabilityDays, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, A.SpecialCare, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID LEFT JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID LEFT JOIN Zone Z ON T.ZoneID = Z.ZoneID LEFT JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE (Day = @Day AND Month = @Month AND Year = @Year AND E.EmployeeID = @EmployeeID)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            try
            {
                sqlParameters.Add(new SqlParameter("@Day", date.Day));
                sqlParameters.Add(new SqlParameter("@Month", date.Month));
                sqlParameters.Add(new SqlParameter("@Year", date.Year));
                sqlParameters.Add(new SqlParameter("@EmployeeID", employeeId));
                return GetSchedules(Query, sqlParameters);
   
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
		}

		public int AmountOfEmployessAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId)
		{
			string Query = "SELECT COUNT(EmployeeID) FROM Schedule WHERE Day = @day AND Month = @month AND Year = @year AND TimeblockID = @timeblockId AND TaskID = @taskId;";
			List<SqlParameter> sqlParameters = new List<SqlParameter>();
			sqlParameters.Add(new SqlParameter("@day", day));
			sqlParameters.Add(new SqlParameter("@month", month));
			sqlParameters.Add(new SqlParameter("@year", year));
			sqlParameters.Add(new SqlParameter("@timeblockId", timeBlockId));
			sqlParameters.Add(new SqlParameter("@taskId", taskID));

            int amountOfEmployessAssigned = 0;

			try
			{
				SqlConnection connection = GetConnection();
				using (SqlCommand command = new SqlCommand(Query, connection))
				{
					command.Parameters.AddRange(sqlParameters.ToArray());

					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						amountOfEmployessAssigned = reader.GetInt32(0);
					}
					connection.Close();
				}
			}
			catch (System.Data.SqlTypes.SqlNullValueException)
			{
				return amountOfEmployessAssigned;
			}
			catch (SqlException ex)
			{
				throw new Exception(ex.ToString());
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
			return amountOfEmployessAssigned;
		}

        public bool DoesEmplyeeIsAssignedToTaskTimeBlockDate(int day, int month, int year, int taskID, int timeBlockId, int employeeID)
        {
            string Query = "SELECT COUNT(EmployeeID) FROM Schedule WHERE Day = @day AND Month = @month AND Year = @year AND TimeblockID = @timeblockId AND TaskID = @taskId AND EmployeeID = @employeeID ";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@day", day));
            sqlParameters.Add(new SqlParameter("@month", month));
            sqlParameters.Add(new SqlParameter("@year", year));
            sqlParameters.Add(new SqlParameter("@timeblockId", timeBlockId));
            sqlParameters.Add(new SqlParameter("@taskId", taskID));
            sqlParameters.Add(new SqlParameter("@employeeID", employeeID));

            try
            {
                SqlConnection connection = GetConnection();
                using (SqlCommand command = new SqlCommand(Query, connection))
                {
                    command.Parameters.AddRange(sqlParameters.ToArray());

                    connection.Open();
                    int UserExist = (int)command.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (System.Data.SqlTypes.SqlNullValueException)
            {
                return false;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }
}
