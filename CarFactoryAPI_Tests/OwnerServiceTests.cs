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
        //ref of test helper

        ITestOutputHelper testOutputHelper;

        //ref from original class 
        IOwnersService ownersService;

        //ref from mock dependencies
        Mock<ICarsRepository> carsRepoMock;
        Mock<IOwnersRepository> ownersRepoMock;
        Mock<ICashService> cashServiceMock;


        public OwnerServiceTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;

            //intializing mock dependencies

            carsRepoMock = new Mock<ICarsRepository>();
            ownersRepoMock = new Mock<IOwnersRepository>();
            cashServiceMock = new Mock<ICashService>();




            //injecting mock dependencies and intializing original class 
            ownersService =new OwnersService(carsRepoMock.Object, ownersRepoMock.Object, cashServiceMock.Object);



        }
        //1- no car 
        [Fact]
        public void BuyCar_NoCar_dosntExist()
        {
            // mocking
            // 2-preparing mocking data
            Car mockCar = null;
            Owner owner = new() { Id = 2, Name = "Omar" };
            //3- mocking setup
            carsRepoMock.Setup(o => o.GetCarById(11)).Returns(mockCar);



            // arrange 

            BuyCarInput buyCarInput = new BuyCarInput() { Amount = 1000, CarId = 11, OwnerId = 1 };
            //act

       string result =     ownersService.BuyCar(buyCarInput);

            //assert

            Assert.Equal("Car doesn't exist", result);




        }
        //2- car sold
        [Fact]
        public void BuyCar_carHasOwner_AlreadySold()
        {
            // mocking
            // 2-preparing mocking data

            Car mockCar = new Car() { Id = 1, OwnerId = 2, Velocity = 20, Owner= new() { Id = 2, Name = "Omar" } };

            //3- mocking setup

            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(mockCar);

            // arrange 
            BuyCarInput buyCarInput = new BuyCarInput() { CarId = 1, Amount = 1000, OwnerId = 2 };

            //act

            string result=ownersService.BuyCar(buyCarInput);
            //assert

            Assert.Equal("Already sold", result);




        }


        //3- Owner doesn't exist
        [Fact]
        public void BuyCar_carInputHasNoOwner_OwnerDosntExist()
        {
            // mocking
            // 2-preparing mocking data
            Car car=new Car() { Id=1,OwnerId=4,Type=CarType.Audi,Velocity=120};
            Owner owmer = null;

            //3- mocking setup
            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(car);
            ownersRepoMock.Setup(x => x.GetOwnerById(4)).Returns(owmer);

            // arrange 

            BuyCarInput buyCarInput=new BuyCarInput() { CarId=1,OwnerId=3,Amount=1000};
            //act

            string result = ownersService.BuyCar(buyCarInput);
            //assert

            Assert.Equal("Owner doesn't exist", result);





        }




        //4- Already have car
        [Fact]
        public void BuyCar_OwnerInputHAsCar_AlreadyHas()
        {
            // mocking
            // 2-preparing mocking data
            Car car = new Car() { Id = 1, OwnerId = 3, Velocity = 200 };
            Owner owmer = new Owner() { Id = 4, Car = new Car(), Name = "Ammar" };



            //3- mocking setup
            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(car);
            ownersRepoMock.Setup(x => x.GetOwnerById(4)).Returns(owmer);




            // arrange 

            BuyCarInput buyCarInput = new BuyCarInput() {CarId=1, OwnerId=4,Amount =1000};



            //act
            string result = ownersService.BuyCar(buyCarInput);
            //assert


            Assert.Equal("Already have car", result);



        }

        //5- Insufficient funds
        [Fact]
        public void BuyCar_carInputAmountless_Insufficent()
        {
            // mocking
            // 2-preparing mocking data
            Car car =new Car() { Id=1,OwnerId=4, Velocity = 200 ,Price=1001};
            Owner owner = new Owner(4, "ammar");


            //3- mocking setup
            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(car);
            ownersRepoMock.Setup(x => x.GetOwnerById(4)).Returns(owner);
            // arrange 

            BuyCarInput buyCarInput= new() { CarId=1,Amount =1000,OwnerId=4};
            //act
            string result = ownersService.BuyCar(buyCarInput);
            //assert

            Assert.Equal("Insufficient funds", result);




        }
        //6-Something went wrong
        [Fact]
        public void BuyCar_case_Resu()
        {
            // mocking
            // 2-preparing mocking data
            Car car = new Car() { Id = 1, Velocity = 130, Price = 1000 };

            Owner owner = new Owner(1, "ammar");

            //3- mocking setup

            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(car);

            ownersRepoMock.Setup(X => X.GetOwnerById(1)).Returns(owner);
            carsRepoMock.Setup(x=>x.AssignToOwner(1,1)).Returns(false);

            // arrange 
            BuyCarInput buyCarInput = new() { CarId = 1, Amount = 1000, OwnerId = 1 };
            //act


            string result = ownersService.BuyCar(buyCarInput);
            //assert

            Assert.Equal("Something went wrong", result);




        }



        //7- Successfull
        [Fact]
        public void BuyCar_sucess_StartsWithSuccessfull()
        {
            // mocking
            // 2-preparing mocking data
            Car car = new Car() { Id=1 ,Velocity=110,Price=1000,Type=CarType.Audi};

            Owner owner = new Owner(1, "Ammar");

            //3- mocking setup
            carsRepoMock.Setup(x => x.GetCarById(1)).Returns(car);
            carsRepoMock.Setup(x => x.AssignToOwner(1,1)).Returns(true);
            ownersRepoMock.Setup(x => x.GetOwnerById(1)).Returns(owner);
            // arrange 
            BuyCarInput buyCarInput= new BuyCarInput() { CarId=1,Amount = 1000, OwnerId = 1 };
            //act
            string result = ownersService.BuyCar(buyCarInput);
            //assert

            Assert.StartsWith("Successfull", result);




        }







       










        public void Dispose()
        {
            testOutputHelper.WriteLine("rescoureces cleaned up ");
        }
    }




































  
}
