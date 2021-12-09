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
    }
}
