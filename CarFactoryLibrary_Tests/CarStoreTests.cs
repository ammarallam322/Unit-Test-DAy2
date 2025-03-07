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
        //ref from carstore
        CarStore carStore;

        public CarStoreTests()
        {
            this.carStore = new CarStore();
        }






        [Fact]
        public void AddCar_addNewToyota_CollectionContainsToyota()
        {
            // Arrange
            CarStore carStore = new CarStore();
            Toyota toyota = new Toyota() { velocity = 15, drivingMode = DrivingMode.Forward };
            BMW bmw = new BMW() { velocity = 15, drivingMode = DrivingMode.Forward };

            // Act
            //Assert.Empty(carStore.cars);
            //Assert.Contains<Car>(toyota,carStore.cars);
            carStore.AddCar(toyota);

            // Assert
            Assert.NotEmpty(carStore.cars);
            Assert.Contains<Car>(toyota, carStore.cars);  // Value Equality
            Assert.Contains<Car>(bmw, carStore.cars);  // Value Equality  // use Equals Method
        }








        //3- collection add car bmw 

        [Fact]

        public void AddCar_AddNewBMW_CollectionContainsBMW()
        {
            //arrange
            BMW bmw = new BMW() { velocity = 10, drivingMode = DrivingMode.Forward };

            //act
            Assert.Empty(carStore.cars);
            carStore.AddCar(bmw);
            //assert
            Assert.NotEmpty(carStore.cars);

            Assert.Contains<Car>(bmw, carStore.cars);

        }

        //3- collection  add list of cars Audi

        [Fact]
        public void AddCars_AddNewListOfAudi_ColletionContainsAudi()
        {
            //arrange
            List<Car> list = new List<Car>() {

                new Audi(){velocity=0,drivingMode=DrivingMode.Stopped},
                new Audi(){velocity=120,drivingMode=DrivingMode.Forward},
                new Audi(){velocity=40,drivingMode=DrivingMode.Backward},

            };


            Assert.Empty(carStore.cars);
            //act 
            carStore.AddCars(list);
            int count=carStore.cars.Count;

            // assert 

            Assert.NotEmpty(carStore.cars);
            Assert.Equal(3,count);



        }




    }
}
