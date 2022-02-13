using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFuelService
    {

        IResult Add(Fuel fuel);

        IResult Update(Fuel fuel);

        IResult Delete(Fuel fuel);
        IDataResult<List<Fuel>> GetAll();
        IDataResult<Fuel> GetFuelById(int id);

    }
}
