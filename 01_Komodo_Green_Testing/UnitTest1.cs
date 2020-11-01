using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle_Repo;

namespace _01_Komodo_Green_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddVehicleToList_ShouldGetCorrectBoolean()
        {
            //Arrange
            Vehicle vehicle = new Vehicle();
            VehicleRepo repo = new VehicleRepo();

            //Act
            bool addResult = repo.AddVehicleToProgram(vehicle);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            Vehicle newVehicle = new Vehicle();
            VehicleRepo repo = new VehicleRepo();

            repo.AddVehicleToProgram(newVehicle);

            //Act
            List<Vehicle> listVehicles = repo.GetVehicles();

            bool directoryHasContent = listVehicles.Contains(newVehicle);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByModel_ShouldReturnCorrectContent()
        {
            //Arrange
            VehicleRepo repo = new VehicleRepo();
            Vehicle newVehicle = new Vehicle(3, "Honda", "CRV", 2017, 22.5, 455);
            repo.AddVehicleToProgram(newVehicle);
            string make = "CRV";

            //Act
            Vehicle searchResult = repo.GetVehicleByModel(make);
            //Assert
            Assert.AreEqual(searchResult.Make, make);
        }

        [TestMethod]
        public void UpdateExistingVehilce_ShouldReturnTrue()
        {
            //Arrange
            VehicleRepo repo = new VehicleRepo();
            Vehicle oldVehicle = new Vehicle(3, "Honda", "CRV", 2017, 22.5, 455);
            repo.AddVehicleToProgram(oldVehicle);

            Vehicle newVehicle = new Vehicle(3, "Honda", "Civic", 2017, 22.5, 455);

            //Act
            bool updateResult = repo.UpdateExistingVehicle(oldVehicle.Make, newVehicle);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            VehicleRepo repo = new VehicleRepo();
            Vehicle newVehicle = new Vehicle(3, "Honda", "CRV", 2017, 22.5, 455);
            repo.AddVehicleToProgram(newVehicle);
            string make = "CRV";

            //Act
            Vehicle oldContent = repo.GetVehicleByModel("CRV");

            bool removeResult = repo.DeleteExistingVehicle(oldContent);

            //Assert
            Assert.IsTrue(removeResult);
        }
    }
}
    }
}
