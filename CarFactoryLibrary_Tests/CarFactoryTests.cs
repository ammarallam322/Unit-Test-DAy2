using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class CarFactoryTests
    {
        [Fact]
        public void NewCar_AskForToyota_ObjectOfToyota()
        {
            // Arrange

            // act
            Car? myCar = CarFactory.NewCar(CarTypes.Toyota);

            // assert
            Assert.NotNull(myCar);
            Assert.IsType<Toyota>(myCar);

            Toyota car = myCar as Toyota;
            Assert.IsAssignableFrom<Car>(car);
        }

        [Fact]
        public void NewCar_AskForHonda_ThrowNotImplementedEx()
        {
            // arrang


           

            // assert
            //Assert.Throws(typeof(NotImplementedException), () =>
            //{
            //    // act
            //    Car? car = CarFactory.NewCar(CarTypes.Honda);
            //});

            Assert.Throws<NotImplementedException>(() => {
                // act
                Car? car = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}
