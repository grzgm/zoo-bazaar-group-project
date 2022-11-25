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
    public class UnavailabilityScheduleRepository : BaseRepository, IUnavailabilityScheduleRepository
    {
        private IEnumerable<UnavailabilityScheduleDTO> GetUnSchedule(string Query, List<SqlParameter>? sqlParameters)
        {
            List<UnavailabilityScheduleDTO> unSchedules = new List<UnavailabilityScheduleDTO>();
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
                        int employeeID = reader.GetInt32(1);
                        DateTime date = reader.GetDateTime(2);

                        unSchedules.Add(new UnavailabilityScheduleDTO
                        {
                            EmployeeID = employeeID,
                            Date = date,
                        });
                    }
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

            return unSchedules;
        }

        void IUnavailabilityScheduleRepository.AddUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO)
        {
            string Query = "INSERT INTO UnavailabilitySchedule VALUES (@EmployeeID,@Date)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", unavailabilityScheduleDTO.EmployeeID));
                sqlParameters.Add(new SqlParameter("@Date", unavailabilityScheduleDTO.Date));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        void IUnavailabilityScheduleRepository.DeleteUnSchedule(UnavailabilityScheduleDTO unavailabilityScheduleDTO)
        {
            string Query = "DELETE FROM UnavailabilitySchedule WHERE (EmployeeID=@EmployeeID AND Date=@Date)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID", unavailabilityScheduleDTO.EmployeeID));
                sqlParameters.Add(new SqlParameter("@Date", unavailabilityScheduleDTO.Date));
                Execute(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        IEnumerable<UnavailabilityScheduleDTO> IUnavailabilityScheduleRepository.GetByEmployeeIDMonthYear(int employeeid, int month, int year)
        {
            string Query = "SELECT * FROM UnavailabilitySchedule WHERE (EmployeeID=@EmployeeID AND MONTH(Date)=@Month AND YEAR(Date)=@Year)";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                sqlParameters.Add(new SqlParameter("@EmployeeID",employeeid));
                sqlParameters.Add(new SqlParameter("@Month", month));
                sqlParameters.Add(new SqlParameter("@Year", year));
                return GetUnSchedule(Query, sqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
