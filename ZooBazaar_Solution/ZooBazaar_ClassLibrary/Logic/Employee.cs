﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_Interfaces.DTOs;

namespace ZooBazaar_ClassLibrary
{
    public enum ROLE
    {
        OFFICE,
        CARETAKER
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

        }
    }
}
