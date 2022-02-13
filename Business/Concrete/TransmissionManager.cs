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
    public class TransmissionManager : ITransmissionService
    {

        private ITransmissionDal _transmissionDal;

        public TransmissionManager(ITransmissionDal transmissionDal)
        {
            _transmissionDal = transmissionDal;
        }

        public IResult Add(Transmission transmission)
        {
            _transmissionDal.Add(transmission);

            return new SuccessResult(">> Transmission is added.");
        }

        public IResult Delete(Transmission transmission)
        {
            _transmissionDal.Delete(transmission);

            return new SuccessResult(">> Transmission is deleted.");
        }

        public IDataResult<List<Transmission>> GetAll()
        {
            return new SuccessDataResult<List<Transmission>>(_transmissionDal.GetAll(), ">> Transmission are fetched.");
        }

        public IDataResult<Transmission> GetTransmissionById(int id)
        {
            Transmission transmission = _transmissionDal.GetAll(t => t.Id == id).First();

            return new SuccessDataResult<Transmission>(transmission, ">> Transmisssion fetched by id.");
        }

        public IResult Update(Transmission transmission)
        {
            _transmissionDal.Update(transmission);

            return new SuccessResult(">> Transmission is updated.");

        }
    }
}
