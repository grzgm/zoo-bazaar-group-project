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
    public class ZoneTests
    {
        FakeData fakeData = new FakeData();
        [TestMethod]
        public void MappingZones()
        {


            // Arrange
            var mockZoneRepostory = new Mock<IZoneRepository>();
            mockZoneRepostory.Setup(x => x.GetAll()).Returns(fakeData.GetFakeZones());


            var zoneMenager = new ZoneManager(mockZoneRepostory.Object);

            //Act 
            List<Zone> zones = zoneMenager.GetAll();



            //Assert
            Assert.IsNotNull(zones);
            Assert.AreEqual(10, zones.Count);
        }
    }
}
