using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Variables
            ICarDal inMemoryCarDal = new InMemoryCarDal();
            ICarService carManager = new CarManager(inMemoryCarDal);

            // Get All Cars
            List<Car> cars = carManager.GetAll();

            // Add new car
            Car testCar = new Car { Id = 10, BrandId = 3, ColorId = 2, DailyPrice = 100, Description = "new car", ModelYear = 2015 };
            carManager.Add(testCar);
            printCars(cars);


            // Get car by id
            Car carToGet = carManager.GetById(10);
            Console.WriteLine(carToGet.ToString());


            // Update a car
            Car updatedCar = new Car { Id = 7, BrandId = 5, ColorId = 9, DailyPrice = 80, Description = "updated car", ModelYear = 2015 };
            carManager.Update(testCar.Id,updatedCar);
            printCars(cars);

            // Delete a car
            carManager.Delete(testCar.Id);
            printCars(cars);

        }
        // Print all cars
        static void printCars(List<Car> cars)
        {
            foreach (Car tempCar in cars)
            {
                Console.WriteLine(tempCar.ToString());
            }
            Console.WriteLine();
        }
    }
}
