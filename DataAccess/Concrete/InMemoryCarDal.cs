using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {                
                new Car{Id = 1,BrandId=1, ColorId=1,  ModelYear = 1999, DailyPrice=70, Description="test description"},
                new Car{Id = 2,BrandId=2, ColorId=1,  ModelYear = 2003, DailyPrice=50, Description="test description1"},
                new Car{Id = 3,BrandId=2, ColorId=3,  ModelYear = 2007, DailyPrice=90, Description="test description2"},
                new Car{Id = 4,BrandId=3, ColorId=1,  ModelYear = 2002, DailyPrice=60, Description="test description3"},


            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("New car is added.");
        }

        public void Delete(int carId)
        {
            Car carToDelete = _cars.Where(tempCar => tempCar.Id == carId).First();
            _cars.Remove(carToDelete);
            Console.WriteLine("Given car is deleted");


        }

        public List<Car> GetAll()
        {
            Console.WriteLine("All cars are get.");
            return _cars;
        }

        public Car GetById(int id)
        {
            Console.WriteLine("Car get by id.");
            return _cars.Where(tempCar => tempCar.Id == id).First();
        }

        public void Update(int carId,Car UpdatedCar)
        {
            Car carToUpdate = _cars.Where(tempCar => tempCar.Id == carId).First();
            carToUpdate.Id = UpdatedCar.Id;
            carToUpdate.BrandId = UpdatedCar.BrandId;
            carToUpdate.ColorId = UpdatedCar.ColorId;
            carToUpdate.DailyPrice = UpdatedCar.DailyPrice;
            carToUpdate.Description = UpdatedCar.Description;
            Console.WriteLine("Car is updated.");
        }
    }
}
