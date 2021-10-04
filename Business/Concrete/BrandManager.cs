using Business.Abstract;
using Core.Business.Abstract;
using Core.DataAccess.EntityFramework.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : BaseService<IBrandDal, Brand>,IBrandService
    {
        public BrandManager(IBrandDal entityDal) : base(entityDal) { }

        public override IResult Add(Brand entity)
        {
            return base.Add(entity);
        }

        public override IResult Delete(Brand entity)
        {
            return base.Delete(entity);
        }

        public override IDataResult<List<Brand>> GetAll()
        {
            return base.GetAll();
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_entityDal.Get(b => b.Id == id));
        }

        public override IDataResult<Brand> Update(Brand entity)
        {
            return base.Update(entity);
        }
    }
}
