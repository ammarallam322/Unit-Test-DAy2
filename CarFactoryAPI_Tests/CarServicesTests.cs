using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace CarFactoryAPI_Tests
{
    public  class CarServicesTests : IDisposable
    {

        //
        ITestOutputHelper outputhelper;

        // ref of mocks
        Mock<ICarsRepository> carsRepoMock;

        //ref of origin class
        ICarsService carsService;




        public CarServicesTests(ITestOutputHelper outputhelper)
        {
            this.outputhelper = outputhelper;

            //mocking shared data
            this.carsRepoMock = new();

            this.carsService = new CarsService(carsRepoMock.Object);

        }


        //1-
        [Fact]

        public void GetAll_NoCars_Null()
        {

            // mocking
            // 2-preparing mocking data
            List<Car> cars = null;
            //3- mocking setup
            carsRepoMock.Setup(x => x.GetAllCars()).Returns(cars);

            // arrange 

            //act
            List<Car> result = carsService.GetAll();


            //assert

            Assert.Null(result);


        }


        // mocking
        // 2-preparing mocking data
        //3- mocking setup

        // arrange 
        //act
        //assert


        public void Dispose()
        {
            outputhelper.WriteLine("resources cleaned up");

        }
    }
}
