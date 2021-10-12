using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public CarManager(ICarDal CarDal)
        {
            this._carDal = CarDal;

        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public void Delete(int carId)
        {
            _carDal.Delete(carId);
        }

        public List<Car> GetAll()
        {
           return  _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

        public void Update(int carId, Car updatedCar)
        {
            _carDal.Update(carId, updatedCar);
        }
    }
}
