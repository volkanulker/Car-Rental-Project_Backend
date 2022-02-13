using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Model = car.Model,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetFilteredCars(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             where car.BrandId == brandId 
                             && car.ColorId == colorId
                             && car.DailyPrice >= minDailyPrice
                             && car.DailyPrice <= maxDailyPrice
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Model = car.Model,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                             };
                return result.ToList();

            }
        }
        public List<CarDetailsWithImageDto> GetCarDetailsWithImage(int carId)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join carimage in context.CarImages
                             on car.Id equals carimage.CarId
                             where car.Id == carId
                             select new CarDetailsWithImageDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 Model = car.Model,
                                 ModelYear = car.ModelYear,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ImagePath = carimage.ImagePath
                             };

                return result.ToList();

            }
        }

        public List<CarCardDto> GetCarCards()
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join carimage in context.CarImages
                             on car.Id equals carimage.CarId
                             join transmission in context.Transmissions
                             on car.TransmissionId equals transmission.Id
                             join fuel in context.Fuels
                             on car.FuelId equals fuel.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id

                             select new CarCardDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 Model = car.Model,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = carimage.ImagePath,
                                 NumberOfSeats = car.NumberOfSeats,
                                 TransmissionName = transmission.Name,
                                 FuelName = fuel.Name,
                                 ColorName = color.Name
                              
                             };

                return result.ToList();

            }
        }

        public List<CarCardDto> GetFilteredCarCards(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join carimage in context.CarImages
                             on car.Id equals carimage.CarId
                             join transmission in context.Transmissions
                             on car.TransmissionId equals transmission.Id
                             join fuel in context.Fuels
                             on car.FuelId equals fuel.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             where car.BrandId == brandId
                             && car.ColorId == colorId
                             && car.DailyPrice >= minDailyPrice
                             && car.DailyPrice <= maxDailyPrice

                             select new CarCardDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 Model = car.Model,
                                 DailyPrice = car.DailyPrice,
                                 ImagePath = carimage.ImagePath,
                                 NumberOfSeats = car.NumberOfSeats,
                                 TransmissionName = transmission.Name,
                                 FuelName = fuel.Name,
                                 ColorName = color.Name

                             };

                return result.ToList();

            }
        }

    }
}
