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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentalToAdd = _rentalDal.Get(r => r.CarId == rental.CarId);
            if(rentalToAdd == null || rentalToAdd.ReturnDate < DateTime.Now.Date)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(">> New rental is added.");
            }
            return new ErrorResult(">> Rental conditions are not provided.");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(">> Given rental is deleted.");
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentals = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(rentals, ">> Rentals are listed.");
        }

        public IDataResult<Rental> GetRentalById(int id)
        {
            var rental = _rentalDal.GetAll(r => r.Id == id).First();
            return new SuccessDataResult<Rental>(rental, ">> Rental is got by Id.");
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(">> Given rental is updated.");
        }
    }
}
