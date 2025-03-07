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

            Assert.Throws<NotImplementedException>(() =>
            {
                // act
                Car? car = CarFactory.NewCar(CarTypes.Honda);
            });
        }









        //5- type Assert 

        [Fact]

        public void NewCar_AskForAudi_null()
        {

            //arrange

            //act
            Car? audi = CarFactory.NewCar(CarTypes.Audi);

            //assert 
            Assert.Null(audi);





        }

        [Fact]

        public void NewCar_AskForBMW_objectOfBMW()
        {
            //arrange

            //act
            Car? bmw = CarFactory.NewCar(CarTypes.BMW);


            //assert

            Assert.NotNull(bmw);
            Assert.IsType<BMW>(bmw);



        }


        //6- exception


        [Fact]
        public void NewCar_AskforAudi_ThrowNullexception()
        {

            //arange

            //assert
            Assert.Throws<ArgumentNullException>( () =>
            {
                //act 
                Car? audi=CarFactory.NewCar(CarTypes.Audi);
                if (audi == null) { throw new ArgumentNullException(); }


            });







        }









    }

}
