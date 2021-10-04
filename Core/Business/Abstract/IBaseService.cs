using Core.Utilities.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business.Abstract
{
    public interface IBaseService<E>
    {
        IResult Add(E entity);

        IResult Delete(E entity);

        IDataResult<List<E>> GetAll();

        IDataResult<E> Update(E entity);

    }
}
