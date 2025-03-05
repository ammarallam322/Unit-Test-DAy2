using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CarFactoryLibrary;

namespace CarFactoryLibrary_Tests
{


    public class ToyotaTests
    {
        //[Fact]  => when test Method have no parameters
        //[Theory]=> when test Method have parameters  [Data Driven Tests]

        [Fact]
        public void IsStopped_Velocity0_True()
        {
            //Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 0;

            //Act 
            bool actualResult = toyota.IsStopped();

            //Boolean Assert
            Assert.True(actualResult);
        }
        [Fact]
        public void IsStopped_Velocity10_False()
        {
            //Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 10;

            //Act 
            bool actualResult = toyota.IsStopped();

            //Boolean Assert
            Assert.False(actualResult);
        }

        [Fact]
        public void GetDirection_CarMovesForward_Forward()
        {
            //Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 10;
            toyota.drivingMode = DrivingMode.Forward;

            //Act
            string actualResult = toyota.GetDirection();

            //string Assert
            Assert.Equal("Forward", actualResult);
            Assert.Equal("forward", actualResult, ignoreCase: true);

            Assert.StartsWith("For", actualResult);
            Assert.StartsWith("for", actualResult, StringComparison.OrdinalIgnoreCase);

            Assert.EndsWith("rd", actualResult);

            Assert.Contains("wa", actualResult);
            Assert.DoesNotContain("rf", actualResult);

            Assert.Matches("F[a-z]{6}", actualResult);
           // Assert.DoesNotMatch()
        }

        [Fact]
        public void Stop_CarVelocity20DirectionBackword_Velocity0DirectionStopped()
        {
            // Arrange
            Toyota toyota = new();
            toyota.velocity = 20;
            toyota.drivingMode = DrivingMode.Backward;

            // Act
            toyota.Stop();

            // Equality Assert
            Assert.Equal(0, toyota.velocity);
            Assert.Equal<DrivingMode>(DrivingMode.Stopped, toyota.drivingMode);
        }

        [Fact]
        public void TimeToCoverDistance_Velocity50Distance100_Time2()
        {
            // Arrange
            Toyota toyota = new();
            toyota.velocity = 50;

            // Act
            double actualTime = toyota.TimeToCoverDistance(100);

            // Numeric Assert
            Assert.Equal(2, actualTime);

            Assert.InRange(actualTime, 1, 3);
            Assert.NotInRange(actualTime, 4, 5);

            Assert.True(actualTime > 1);
        }


        [Fact]
        public void GetMyCar_referToObject_SameObject()
        {
            // Arrange
            Toyota toyota = new() { drivingMode = DrivingMode.Forward, velocity= 10};

            // Act
            Car newRef = toyota.GetMyCar();

            // Assert
            Assert.NotNull(newRef);

            Assert.Same(toyota, newRef); // check two references to the same object [one object in mermory]

        }
    }
}