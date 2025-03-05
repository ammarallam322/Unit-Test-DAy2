using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarStoreTests
    {
        [Fact]
        public void AddCar_addNewToyota_CollectionContainsToyota()
        {
            // Arrange
            CarStore carStore = new CarStore();
            Toyota toyota = new Toyota() {velocity=15, drivingMode=DrivingMode.Forward };
            BMW bmw = new BMW() {velocity=15, drivingMode=DrivingMode.Forward };

            // Act
            //Assert.Empty(carStore.cars);
            //Assert.Contains<Car>(toyota,carStore.cars);
            carStore.AddCar(toyota);

            // Assert
            Assert.NotEmpty(carStore.cars);
            Assert.Contains<Car>(toyota,carStore.cars);  // Value Equality
            Assert.Contains<Car>(bmw,carStore.cars);  // Value Equality  // use Equals Method
        }
    }
}
