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
    public class HabitiatTests
    {
        FakeData fakeData = new FakeData();
        [TestMethod]
        public void MappingHabitats()
        {


            // Arrange
            var mockHabitatlRepostory = new Mock<IHabitatRepository>();
            mockHabitatlRepostory.Setup(x => x.GetAll()).Returns(fakeData.GetAllFakeHabitats());


            var habitatMenager = new HabitatManager(mockHabitatlRepostory.Object);

            //Act 
            List<Habitat> habitats = habitatMenager.GetAll();



            //Assert
            Assert.IsNotNull(habitats);
            Assert.AreEqual(10, habitats.Count);
        }
    }
}
