using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryAPI_Tests.Stups
{
    internal class CarRepoStup : ICarsRepository
    {
        public bool AddCar(Car car)
        {
            throw new NotImplementedException();
        }

        public bool AssignToOwner(int carId, int OwnerId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Car GetCarById(int id)
        {
            return new Car() { Id = 3, Price= 20000, Type=CarType.Audi, VIN="78995", Velocity=100, OwnerId=10, Owner=new Owner()};
        }

        public bool Remove(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
