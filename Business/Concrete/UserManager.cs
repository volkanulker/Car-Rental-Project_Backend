using Business.Abstract;
using Core.Entities;
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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;

        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(">> New User is added.");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(">> New User is deleted.");
        }

        public IDataResult<List<User>> GetAll()
        {
            var allUsers = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(allUsers,">> All users are listed.");
        }

        public IDataResult<User> GetByMail(string email)
        {
            User userToGet = _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(userToGet,">> User get by mail.");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var operationClaims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(operationClaims,">> Operation claims are got.");
        }

        public IDataResult<User> GetUserById(int id)
        {
            User userToGet = _userDal.GetAll(u => u.Id == id).First();
            return new SuccessDataResult<User>(userToGet, ">> Given user is got by ID.");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(">> User is updated.");
        }
    }
}
