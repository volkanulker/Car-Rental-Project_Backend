using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetUserById(int id);

        IDataResult<List<User>> GetAll();

        IResult Add(User user);

        IResult Update(User user);

        IResult Delete(User user);
    }
}
