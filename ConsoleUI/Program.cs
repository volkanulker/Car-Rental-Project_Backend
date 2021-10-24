using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Collections;
using Entities.DTOs;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Variables
            ICarDal efCarDal = new EfCarDal();
            ICarService carManager = new CarManager(efCarDal);

            IColorDal efColorDal = new EfColorDal();
            IColorService colorManager = new ColorManager(efColorDal);

            IBrandDal efBrandDal = new EfBrandDal();
            IBrandService brandManager = new BrandManager(efBrandDal);

            ICustomerDal customerDal = new EfCustomerDal();
            ICustomerService customerManager = new CustomerManager(customerDal);

            
            IUserDal userDal = new EfUserDal();
            IUserService userManager = new UserManager(userDal);

            IRentalDal rentalDal = new EfRentalDal();
            IRentalService rentalManager = new RentalManager(rentalDal);


            //Car testCar = new Car { Name = "Astra", BrandId = 1, ColorId = 1, DailyPrice = 100, Description = "test car ", ModelYear = 2002 };
            //Color testColor = new Color {  Name = "Red" };
            //Brand testBrand = new Brand { Name = "Opel" };
            //Customer testCustomer = new Customer {CompanyName = "Test Company" };
            //User testUser = new User {Email="test@email.com", FirstName="testFN", LastName="testLN", Password="testPass" };
            //Rental testRental = new Rental {CarId=1, CustomerId=1, RentDate= new DateTime(2021, 10, 24), ReturnDate=default };


            //rentalManager.Add(testRental);
            //customerManager.Add(testCustomer);
            //userManager.Add(testUser);
            //carManager.Add(testCar);
            //colorManager.Add(testColor);
            //brandManager.Add(testBrand);

            //CarDetailDtoTest(carManager);

            //printColors(colorManager);
            //printBrands(brandManager);



        }

        //private static void CarDetailDtoTest(ICarService carManager)
        //{
        //    List<CarDetailDto> carDetails = carManager.GetCarDetails();

        //    foreach (var carDetail in carDetails)
        //    {
        //        Console.WriteLine("[ CarName: " + carDetail.CarName + "| BrandName:" + carDetail.BrandName + "| ColorName: " + carDetail.ColorName + "| DailyPrice:" + carDetail.DailyPrice + " ]");

        //    }
        //}

        //private static void printBrands(IBrandService brandManager)
        //{
        //    List<Brand> brands = brandManager.GetAll();

        //    foreach (var brand in brands)
        //    {
        //        Console.WriteLine("[ Id:" + brand.Id + " | Name:" + brand.Name + " ]");

        //    }
        //}

        //private static void printColors(IColorService colorManager)
        //{
        //    List<Color> colors = colorManager.GetAll();

        //    foreach (var color in colors)
        //    {
        //        Console.WriteLine("[ Id:" + color.Id + "Name: " + color.Name + " ]");
        //    }
        //}

        // Print List Objects
        static void printList<T>(List<T> objects)
        {
            foreach (var tempObj in objects)
            {
                Console.WriteLine(tempObj.ToString());
            }
            Console.WriteLine();
        }
    }
}
