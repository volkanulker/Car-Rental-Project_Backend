using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarRentalDBContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using(var context = new CarRentalDBContext())
            {
                // join to tables to get Operation Claims of given User
                var result = from OperationClaim in context.OperationClaims
                             join UserOperationClaim in context.UserOperationClaims
                             on OperationClaim.Id equals UserOperationClaim.OperationClaimId
                             where UserOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = OperationClaim.Id, Name = OperationClaim.Name };

                return result.ToList();
                            
            }
        }
    }
}
