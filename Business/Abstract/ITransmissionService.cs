using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransmissionService
    {

        IDataResult<Transmission> GetTransmissionById(int id);

        IDataResult<List<Transmission>> GetAll();

        IResult Add(Transmission transmission);

        IResult Update(Transmission transmission);

        IResult Delete(Transmission transmission);
    }
}
