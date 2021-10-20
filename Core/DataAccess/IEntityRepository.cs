using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    
        // Generic Constraint
        // class: reference type
        // IEntity: It can be IEntity or any object that implements IEntity
        // new(): must be object that can used with new
        public interface IEntityRepository<T>
            where T : class, IEntity, new()
        {

            List<T> GetAll(Expression<Func<T, bool>> filter = null);

            T Get(Expression<Func<T, bool>> filter);
            void Add(T entity);

            void Update(T entity);

            void Delete(T entity);

        
    }
}
