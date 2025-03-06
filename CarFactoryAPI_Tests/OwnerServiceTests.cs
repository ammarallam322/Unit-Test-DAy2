using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPI.Entities;
using CarFactoryAPI.Repositories_DAL;
using CarFactoryAPI_Tests.Stups;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryAPI_Tests
{
    public class OwnerServiceTests : IDisposable
    {
        private readonly ITestOutputHelper testOutputHelper;
        Mock<ICarsRepository> CarRepoMock;
        Mock<IOwnersRepository> OwnerRepoMock;
        Mock<ICashService> cashMock;

        OwnersService ownersService;

        public OwnerServiceTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            testOutputHelper.WriteLine("Test Setup");

            // Create Mock Of Dependencies
            CarRepoMock = new();
            OwnerRepoMock = new();
            cashMock = new();

            // use mock object as a dependency
            ownersService = new(CarRepoMock.Object, OwnerRepoMock.Object, cashMock.Object);

        }
        [Fact]
        public void BuyCar_CarNotExist_NotExist()
        {
            // Arrange

            // use Real Dependencies

            FactoryContext factoryContext = new();

            OwnerRepository ownerRepo = new(factoryContext);
            CarRepository carRepo = new(factoryContext);
            CashService cashService = new();

            OwnersService ownersService = new(carRepo,ownerRepo,cashService);

            BuyCarInput buyCar = new()
            {
               CarId = 3,
               OwnerId = 1,
               Amount = 1000
            };

            // Act
            string Result = ownersService.BuyCar(buyCar);

            // Assert
            Assert.EndsWith("n't exist", Result);
        }

        [Fact]
        public void BuyCar_CarWithOwner_AlreadySold()
        {
            // arrange

            // use Fake Depencies

            CarRepoStup carRepoStup = new();
            OwnerRepoStup ownerRepoStup = new();
            CashService cashService = new();

            OwnersService ownersService = new(carRepoStup, ownerRepoStup, cashService);

            BuyCarInput carInput = new()
            {
                CarId = 3,
                OwnerId = 20,
                Amount = 1000
            };
            // act 
            string result = ownersService.BuyCar(carInput);

            // Assert
            Assert.Equal("Already sold", result);
        }

        [Fact]
        public void BuyCar_OwnerNotExist_NotExist()
        {
            testOutputHelper.WriteLine("Execute test: BuyCar_OwnerNotExist_NotExist");
            // Arrange

            // prepare Mocking Data
            Car car = new() { Id = 2, Price = 1000, Type = CarType.Audi, Velocity = 500, VIN = "558855" };
            Owner owner = null;

            // Setup Mock Methods
            CarRepoMock.Setup(o => o.GetCarById(2)).Returns(car);
            OwnerRepoMock.Setup(o => o.GetOwnerById(3)).Returns(owner);

            BuyCarInput buyCarInput = new()
            {
                CarId = 2,
                OwnerId = 10,
                Amount = 1000
            };

            // Act
            string result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.EndsWith("n't exist", result);
        }

        [Fact]
        public void BuyCar_MoneyNotEnough_InsifissuntAmount()
        {
            testOutputHelper.WriteLine("Execute Test: BuyCar_MoneyNotEnough_InsifissuntAmount");
            // Arrange

            //// Create Mock Of Dependencies
            //Mock<ICarsRepository> carRepoMock = new();
            //Mock<IOwnersRepository> ownerRepoMock = new();
            //Mock<ICashService> cashMock = new();

            // prepare mocking data
            Car car = new(){ Id = 2, Price = 1000, Type = CarType.Audi, Velocity = 500, VIN = "558855" };
            Owner owner = new() { Id =2, Name = "Omar"};

            // Setup Mock Methods
            CarRepoMock.Setup(o => o.GetCarById(It.IsAny<Int32>())).Returns(car);
            OwnerRepoMock.Setup(o => o.GetOwnerById(It.IsAny<Int32>())).Returns(owner);

            // use mock object as a dependency
            //OwnersService ownersService = new(carRepoMock.Object, ownerRepoMock.Object, cashMock.Object);
            
            BuyCarInput buyCarInput = new()
            {
                CarId = 3,
                OwnerId = 7,
                Amount = 100
            };

            // Act
            string result = ownersService.BuyCar(buyCarInput);

            // Assert
            Assert.Equal("Insufficient funds", result);
        }

        public void Dispose()
        {
            testOutputHelper.WriteLine("Test Cleanup");
        }
    }
}
