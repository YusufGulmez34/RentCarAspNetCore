
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework.Abstract
{
    public interface IEntityRepository<T>
    {
         void Add(T entity);

         void Delete(T entity);

         List<T> GetAll(Expression<Func<T,bool>> filter);

         T Get(Expression<Func<T, bool>> filter);

         void Update(T entity);

    }
}
