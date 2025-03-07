using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class BMWTests
    {
        // ref from car 
        Car? myCar;

        public BMWTests()
        {
            this.myCar = new BMW();
        }



        // 1- boolean

        [Fact]
        public void IsStopped_Velocity20_False()
        {

            //arrange
            myCar.velocity = 20;
            //act 
            bool actualResult = myCar.IsStopped();

            //assert
            Assert.False(actualResult);


        }

        //2- string 
        [Fact]
        public void GetDirection_velocity0_drivingmodeStopped()
        {

            //arrange
            myCar.velocity = 0;
            //act
            string actualResult = myCar.GetDirection();
            //assert
            Assert.Equal(DrivingMode.Stopped.ToString(), actualResult);



        }


        //4- numeric
        [Fact]
        public void TimeToCoverDistance_velocity40Distance120_time()
        {

            //arrange
            myCar.velocity = 40;

            //act
            double ActualResult = myCar.TimeToCoverDistance(120);

            //Assert
            Assert.Equal(3, ActualResult);





        }


    }
}
