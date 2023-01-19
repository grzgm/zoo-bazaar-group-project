using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBazaar_ClassLibrary.Menagers;
using ZooBazaar_DomainModels.Models;
using ZooBazaar_DTO.DTOs;
using ZooBazaar_Repositories.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class AnimalTests
    {
        FakeData fakeData = new FakeData();
        [TestMethod]
        public void MappingAnimals()
        {


            // Arrange
            var mockAnimalRepostory = new Mock<IAnimalRepository>();
            mockAnimalRepostory.Setup(x => x.GetAll()).Returns(fakeData.GetAllFakeAnimals());


            var animalMenager = new AnimalManager(mockAnimalRepostory.Object);

            //Act 
            List<Animal> animals = animalMenager.GetAll();



            //Assert
            Assert.IsNotNull(animals);
            Assert.AreEqual(10, animals.Count);
        }
    }
}
