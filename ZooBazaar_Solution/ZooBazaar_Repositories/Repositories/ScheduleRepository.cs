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
    public class ScheduleRepository : BaseRepository, IScheduleRepository
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
            string Query = "DELETE FROM Schedule WHERE ScheduleID = @ScheduleID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ScheduleID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<ScheduleDTO> IScheduleRepository.GetAll()
        {
            List<ScheduleDTO> scheduleDTOs = new List<ScheduleDTO>();
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int scheduleid = reader.GetInt32(0);
                    int day = reader.GetInt32(1);
                    int month = reader.GetInt32(2);
                    int year = reader.GetInt32(3);

                    int schtimeblockid = reader.GetInt32(4);
                    TimeSpan schstartingtime = reader.GetTimeSpan(5);
                    TimeSpan schendingtime = reader.GetTimeSpan(6);

                    int employeeid = reader.GetInt32(5);
                    string empfirstname = reader.GetString(6);
                    string emplastname = reader.GetString(7);
                    string empemail = reader.GetString(8);
                    string empphone = reader.GetString(9);
                    string empaddress = reader.GetString(10);
                    string emprole = reader.GetString(11);

                    int taskid = reader.GetInt32(12);
                    string taskname = reader.GetString(13);

                    int animalid = reader.GetInt32(14);
                    string animalname = reader.GetString(15);
                    int animalage = reader.GetInt32(16);
                    DateTime animaldateofbirth = reader.GetDateTime(17);
                    bool animalsex = reader.GetBoolean(18);
                    string animalspecies = reader.GetString(19);
                    string animalspeciestype = reader.GetString(20);
                    string animaldiet = reader.GetString(21);
                    int animalfeedingtimeid = reader.GetInt32(22);
                    TimeSpan animalstartingtime = reader.GetTimeSpan(23);
                    TimeSpan animalendingtime = reader.GetTimeSpan(24);
                    int animalfeedinginterval = reader.GetInt32(25);

                    int habitatid = reader.GetInt32(26);
                    string habitatname = reader.GetString(27);
                    int habitatcapacity = reader.GetInt32(28);

                    int zoneid = reader.GetInt32(29);
                    string zonename = reader.GetString(30);
                    int zonecapacity = reader.GetInt32(31);

                    scheduleDTOs.Add(new ScheduleDTO
                    {
                        ScheduleID = scheduleid,
                        Day = day,
                        Month = month,
                        Year = year,
                        TimeBlockDTO = new TimeBlockDTO
                        {
                            TimeblockID = schtimeblockid,
                            StartingTime = schstartingtime,
                            EndingTime = schendingtime
                        },
                        EmployeeDTO = new EmployeeDTO
                        {
                            EmployeeID = employeeid,
                            FirstName = empfirstname,
                            LastName = emplastname,
                            Email = empemail,
                            Phone = empphone,
                            Address = empaddress,
                            Role = emprole
                        },
                        TaskDTO = new TaskDTO
                        {
                            TaskID = taskid,
                            Name = taskname,
                            AnimalDTO = new AnimalDTO
                            {
                                AnimalId = animalid,
                                Name = animalname,
                                Age = animalage,
                                DateOfBirth = animaldateofbirth,
                                Sex = animalsex,
                                Species = animalspecies,
                                SpeciesType = animalspeciestype,
                                Diet = animaldiet,
                                FeedingInterval = animalfeedinginterval,
                                TimeBlockDTO = new TimeBlockDTO
                                {
                                    TimeblockID = animalfeedingtimeid,
                                    StartingTime = animalstartingtime,
                                    EndingTime = animalendingtime
                                },
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
                            },
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
            }
            return scheduleDTOs;
        }
        ScheduleDTO IScheduleRepository.GetByScheduleId(int ID)
        {
            ScheduleDTO scheduleDTO = new ScheduleDTO();
            string Query = "SELECT S.ScheduleID, S.Day, S.Month, S.Year, S.TimeblockID, TB.StartingTime, TB.EndingTime, E.EmployeeID, E.FirstName, E.LastName, E.Email, E.Phone, E.Address, E.Role, T.TaskID, T.Name, T.AnimalID, A.Name, A.Age, A.DateOfBirth, A.Sex, A.Species, A.SpeciesType, A.Diet, A.FeedingTimeID, TB2.StartingTime, TB2.EndingTime, A.FeedingInterval, T.HabitatID, H.Name, H.Capacity, H.ZoneID, Z.Name, Z.Capacity FROM Schedule S JOIN Timeblock TB ON S.TimeblockID = TB.TimeblockID JOIN Employee E ON S.EmployeeID = E.EmployeeID JOIN Task T ON S.TaskID = T.TaskID LEFT JOIN Animal A ON T.AnimalID = A.AnimalID JOIN Timeblock TB2 ON A.FeedingTimeID = TB2.TimeblockID JOIN Zone Z ON T.ZoneID = Z.ZoneID JOIN Habitat H ON T.HabitatID = H.HabitatID WHERE ScheduleID = @ID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
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

                    int schtimeblockid = reader.GetInt32(4);
                    TimeSpan schstartingtime = reader.GetTimeSpan(5);
                    TimeSpan schendingtime = reader.GetTimeSpan(6);

                    int employeeid = reader.GetInt32(5);
                    string empfirstname = reader.GetString(6);
                    string emplastname = reader.GetString(7);
                    string empemail = reader.GetString(8);
                    string empphone = reader.GetString(9);
                    string empaddress = reader.GetString(10);
                    string emprole = reader.GetString(11);

                    int taskid = reader.GetInt32(12);
                    string taskname = reader.GetString(13);

                    int animalid = reader.GetInt32(14);
                    string animalname = reader.GetString(15);
                    int animalage = reader.GetInt32(16);
                    DateTime animaldateofbirth = reader.GetDateTime(17);
                    bool animalsex = reader.GetBoolean(18);
                    string animalspecies = reader.GetString(19);
                    string animalspeciestype = reader.GetString(20);
                    string animaldiet = reader.GetString(21);
                    int animalfeedingtimeid = reader.GetInt32(22);
                    TimeSpan animalstartingtime = reader.GetTimeSpan(23);
                    TimeSpan animalendingtime = reader.GetTimeSpan(24);
                    int animalfeedinginterval = reader.GetInt32(25);

                    int habitatid = reader.GetInt32(26);
                    string habitatname = reader.GetString(27);
                    int habitatcapacity = reader.GetInt32(28);

                    int zoneid = reader.GetInt32(29);
                    string zonename = reader.GetString(30);
                    int zonecapacity = reader.GetInt32(31);

                    scheduleDTO = (new ScheduleDTO
                    {
                        ScheduleID = scheduleid,
                        Day = day,
                        Month = month,
                        Year = year,
                        TimeBlockDTO = new TimeBlockDTO
                        {
                            TimeblockID = schtimeblockid,
                            StartingTime = schstartingtime,
                            EndingTime = schendingtime
                        },
                        EmployeeDTO = new EmployeeDTO
                        {
                            EmployeeID = employeeid,
                            FirstName = empfirstname,
                            LastName = emplastname,
                            Email = empemail,
                            Phone = empphone,
                            Address = empaddress,
                            Role = emprole
                        },
                        TaskDTO = new TaskDTO
                        {
                            TaskID = taskid,
                            Name = taskname,
                            AnimalDTO = new AnimalDTO
                            {
                                AnimalId = animalid,
                                Name = animalname,
                                Age = animalage,
                                DateOfBirth = animaldateofbirth,
                                Sex = animalsex,
                                Species = animalspecies,
                                SpeciesType = animalspeciestype,
                                Diet = animaldiet,
                                FeedingInterval = animalfeedinginterval,
                                TimeBlockDTO = new TimeBlockDTO
                                {
                                    TimeblockID = animalfeedingtimeid,
                                    StartingTime = animalstartingtime,
                                    EndingTime = animalendingtime
                                },
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
                            },
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
            }
            return scheduleDTO;
        }

        void IScheduleRepository.Insert(ScheduleDTO dto)
        {
            string Query = "INSERT INTO Schedule VALUES (@Day,@Month,@Year,@TimeblockID,@EmployeeID,@TaskID)";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@Day", dto.Day);
                command.Parameters.AddWithValue("@Month", dto.Month);
                command.Parameters.AddWithValue("@Year", dto.Year);
                command.Parameters.AddWithValue("@TimeblockID", dto.TimeBlockDTO.TimeblockID);
                command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeDTO.EmployeeID);
                command.Parameters.AddWithValue("@TaskID", dto.TaskDTO.TaskID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        int IScheduleRepository.nextID()
        {
            int newID = 1;
            string Query = "SELECT MAX(ScheduleID) FROM Schedule";
            SqlConnection connection = GetConnection();
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
            return newID;

        }

        void IScheduleRepository.Update(ScheduleDTO dto)
        {
            string Query = "UPDATE Schedule SET Day=@Day,Month=@Month,Year=@Year,TimeblockID=@TimeblockID,EmployeeID=@EmployeeID,TaskID=@TaskID WHERE ScheduleID=@ScheduleID";
            SqlConnection connection = GetConnection();
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                command.Parameters.AddWithValue("@ScheduleID", dto.ScheduleID);
                command.Parameters.AddWithValue("@Day", dto.Day);
                command.Parameters.AddWithValue("@Month", dto.Month);
                command.Parameters.AddWithValue("@Year", dto.Year);
                command.Parameters.AddWithValue("@TimeblockID", dto.TimeBlockDTO.TimeblockID);
                command.Parameters.AddWithValue("@EmployeeID", dto.EmployeeDTO.EmployeeID);
                command.Parameters.AddWithValue("@TaskID", dto.TaskDTO.TaskID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
