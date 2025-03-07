using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary_Tests
{
    public class AudiTests
    {

        // ref from car 
        Car? myCar;

        public AudiTests()
        {
            this.myCar = new Audi();
        }



        // 2 string 
        [Fact]
        public void GetDirection_velocity10DirectionBackword_Backward()
        {

            //arrange
            myCar.velocity = 10;
            myCar.drivingMode = DrivingMode.Backward;

            //Act 
            string actualResult = myCar.GetDirection();

            // assert 
            Assert.Equal(DrivingMode.Backward.ToString(), actualResult);


        }


        //4- numeric
        [Fact]
        public void TimeToCoverDistance_velocity100Distance50_time()
        {

            //arrange
            myCar.velocity = 100;

            //act
            double ActualResult = myCar.TimeToCoverDistance(50);

            //Assert
            Assert.Equal(.5, ActualResult);





        }



    }
}
