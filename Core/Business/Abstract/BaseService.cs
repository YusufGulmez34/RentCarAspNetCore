using Core.DataAccess.EntityFramework.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Abstract
{
    public abstract class BaseService<T,E> : IBaseService<E>
        where T:IEntityRepository<E> where E:IEntity, new()
    {
        public T _entityDal;

        protected BaseService(T entityDal)
        {
            _entityDal = entityDal;
        }
        
        public virtual IResult Add(E entity)
        {
            _entityDal.Add(entity);
            return new SuccessResult("Ekleme Başarılı");
        }

        public virtual IResult Delete(E entity)
        {
            _entityDal.Delete(entity);
            return new SuccessResult();
        }

        public virtual IDataResult<List<E>> GetAll()
        {
            return new SuccessDataResult<List<E>>(_entityDal.GetAll(null));
        }

        public virtual IDataResult<E> Update(E entity)
        {
            _entityDal.Update(entity);
            return new SuccessDataResult<E>(entity);
        }
    }
}
