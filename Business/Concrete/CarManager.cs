using Business.Abstract;
using Business.ValidationRules;
using Core.Aspects.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        private ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal CarDal,ICarImageService carImageService)
        {
            this._carDal = CarDal;
            this._carImageService = carImageService;

        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(">> Car is added.");
            
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(">> Given car is updated.");
        }

        public IResult Delete(Car car)
        {
            var deletedCar = _carDal.Get(c => c.Id == car.Id);
            _carImageService.DeleteAllImagesOfCarByCarId(deletedCar.Id);
            _carDal.Delete(deletedCar);
            return new SuccessResult(">> Given car is deleted.");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),">> Cars are got."); 
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),">> Cars are listed by the Brand ID.");  
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),">> Cars are listed by Color ID."); 
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), ">> Car detaisl are listed.");
           
        }

        public IDataResult<Car> GetCarById(int id)
        {
                return new SuccessDataResult<Car>(_carDal.GetAll(c => c.Id == id).First(),">> Car got by ID."); 
        }

        public IDataResult<List<CarDetailsWithImageDto>> GetCarDetailsWithImage(int carId)
        {
            return new SuccessDataResult<List<CarDetailsWithImageDto>>(_carDal.GetCarDetailsWithImage(carId), ">> Car detaisl are listed.");
        }

        public IDataResult<List<CarDetailDto>> GetFilteredCars(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetFilteredCars(brandId, colorId, minDailyPrice, maxDailyPrice),">> Cars are filtered.");
        }

        public IDataResult<List<CarCardDto>> GetCarCards()
        {
            return new SuccessDataResult<List<CarCardDto>>(_carDal.GetCarCards(), ">> Car cards are fetched.");
        }

        public IDataResult<List<CarCardDto>> GetFilteredCarCards(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        {
            return new SuccessDataResult<List<CarCardDto>>(_carDal.GetFilteredCarCards(brandId, colorId, minDailyPrice, maxDailyPrice), ">> Car Cards are filtered.");
        }
    }
}
