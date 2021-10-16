using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
            ICarDal EfCarDal = new EfCarDal();
            ICarService carManager = new CarManager(EfCarDal);

            //Car testCar = new Car { Id = 1, Name = "Astra", BrandId =1, ColorId=1, DailyPrice=100, Description="test car ", ModelYear=2002 };

            //carManager.Add(testCar);

            List<Car> carList = carManager.GetAll();
            printCars(carList);

          

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
