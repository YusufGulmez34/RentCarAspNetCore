using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IBaseService<Rental>
    {
        IDataResult<Rental> GetById(int id);

    }
}
