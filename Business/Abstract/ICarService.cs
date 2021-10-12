using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int id);

        List<Car> GetAll();

        void Add(Car car);

        void Update(int carId, Car updatedCar);

        void Delete(int carId);
    }
}
