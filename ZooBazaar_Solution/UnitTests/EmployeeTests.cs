using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_Repositories.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class EmployeeTests
    {
        FakeData fakeData = new FakeData();
        [TestMethod]
        public void MappingEmployees()
        {


            // Arrange
            var mockEmployeeRepostory = new Mock<IEmployeeRepositroty>();
            mockEmployeeRepostory.Setup(x => x.GetAllEmployees()).Returns(fakeData.GetAllFakeEmployees());


            var employeeMenager = new EmployeeManager(mockEmployeeRepostory.Object);

            //Act 
            List<Employee> employees = employeeMenager.GetAll();



            //Assert
            Assert.IsNotNull(employees);
            Assert.AreEqual(11, employees.Count);
        }
        [TestMethod]
        public void LoginEmployees()
        {


            // Arrange
            var mockEmployeeRepostory = new Mock<IEmployeeRepositroty>();
            mockEmployeeRepostory.Setup(x => x.GetEmployeeByLogin("2@2", "WZRHGrsBESr8wYFZ9sx0tPURuZgG2lmzyvWpwXPKz8U=")).Returns(fakeData.GetFakeEmployee());


            var employeeMenager = new EmployeeManager(mockEmployeeRepostory.Object);

            //Act 
            Employee employee = employeeMenager.LoginEmployee("2@2","12345");



            //Assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(2, employee.ID);
        }
    }
}
