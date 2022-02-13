using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        private IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public IResult Add(Fuel fuel)
        {
            _fuelDal.Add(fuel);
            return new SuccessResult(">>> New fuel is added.");
        }

        public IResult Delete(Fuel fuel)
        {
            _fuelDal.Delete(fuel);
            return new SuccessResult(">>> A fuel is deleted.");
        }

        public IDataResult<List<Fuel>> GetAll()
        {
            return new SuccessDataResult<List<Fuel>>(_fuelDal.GetAll(),">>> All fuels are fetched.");
        }

        public IDataResult<Fuel> GetFuelById(int id)
        {
            return new SuccessDataResult<Fuel>(_fuelDal.GetAll(f => f.Id == id).First(), "Fuel is fetched by id.");
        }

        public IResult Update(Fuel fuel)
        {
            _fuelDal.Update(fuel);
            return new SuccessResult(">>> A fuel is updated.");
        }
    }
}
