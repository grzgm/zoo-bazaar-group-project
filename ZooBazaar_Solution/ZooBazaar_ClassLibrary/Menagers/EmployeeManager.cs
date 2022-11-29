using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Interfaces;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace ZooBazaar_ClassLibrary.Menagers
{
    public class EmployeeManager : IEmployeeMenager
    {
        private readonly IEmployeeRepositroty _employeeRepositroty;
        public EmployeeManager(IEmployeeRepositroty employeeRepositroty)
        {
            this._employeeRepositroty = employeeRepositroty;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();    
            foreach(EmployeeDTO dto in _employeeRepositroty.GetAllEmployees())
            {
                employees.Add(new Employee(dto));
            }
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            return new Employee(_employeeRepositroty.GetByEmployeeId(id));
        }

        public Employee LoginEmployee(string email, string password)
        {
            string hashedpassword = PasswordHash(password);
            EmployeeDTO employeeDTO = _employeeRepositroty.GetEmployeeByLogin(email, hashedpassword);
            if(employeeDTO.FirstName == null)
            {
                return null;
            }
            return new Employee(employeeDTO);
        }

        public void NewEmployee(EmployeeAddDTO employeeDTO)
        {
            string hashedpassword = PasswordHash(employeeDTO.Password);
            employeeDTO.Password = hashedpassword;
            _employeeRepositroty.Insert(employeeDTO);
        }

        public void RemoveEmployee(int id)
        {
            _employeeRepositroty.Delete(id);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            string hashedpassword = PasswordHash(employeeDTO.Password);
            employeeDTO.Password = hashedpassword;
            _employeeRepositroty.Update(employeeDTO);
        }

        private string PasswordHash(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hash = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hash);
        }
    }
}
