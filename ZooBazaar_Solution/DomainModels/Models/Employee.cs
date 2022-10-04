using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_DTO.DTOs;

namespace ZooBazaar_DomainModels.Models
{
    public enum ROLE
    {
        Office,
        Caretaker
    }


    public class Employee
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;
        private string _address;
        private ROLE _role;

        public Employee(int id, string firstName, string lastName, string email, string phone, string address, ROLE role)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _address = address;
            _role = role;
        }
        public Employee(EmployeeDTO employeeDTO)
        {
            this._id = employeeDTO.Id;
            this._firstName = employeeDTO.FirstName;
            this._lastName = employeeDTO.LastName;
            this._email = employeeDTO.Email;
            this._phone = employeeDTO.Phone;
            this._address = employeeDTO.Address;
            this._role = Enum.Parse<ROLE>(employeeDTO.Role);

        }


        public int ID { get { return _id; } }
        public string FirstName { get { return _firstName; } }

        public string LastName { get { return _lastName; } }

        public string Email { get { return _email; } }  

        public string Phone { get { return _phone; } }

        public string Address { get { return _address; } }

        public ROLE Role { get { return _role; } }




    }
}
