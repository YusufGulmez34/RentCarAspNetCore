using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService : IBaseService<Brand>
    {
        IDataResult<Brand> GetById(int id);
    }
}
