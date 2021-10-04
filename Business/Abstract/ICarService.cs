using System.Collections.Generic;
using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService : IBaseService<Car>
    {
        IDataResult<Car> GetById(int id);
        IDataResult<Car> GetByColorId(int colorId);
        IDataResult<Car> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetail();

    }
}