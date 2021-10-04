using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business.Abstract;
using Core.CrossCuttingConsern.Validation;
using Core.Utilities.Abstracts;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : BaseService<ICarDal, Car>, ICarService
    {
        public CarManager(ICarDal entityDal) : base(entityDal) { }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public override IResult Add(Car entity)
        {
            var result = BussinessRules.Run(CheckIfCarNameSame(entity.Name));
            if (!result.Success)
            {
                return result;
            }

            return base.Add(entity);

        }

        private IResult CheckIfCarNameSame(string name)
        {
            if (_entityDal.GetAll(e => e.Name == name).Any())
            {
                return new ErrorResult("Ayný isimden 1 tane zaten var!");
            }

            return null;
        }

        

        public override IResult Delete(Car entity)
        {
            return base.Delete(entity);
        }

        [CacheAspect]
        public override IDataResult<List<Car>> GetAll()
        {
            return base.GetAll();
        }

        public override IDataResult<Car> Update(Car entity)
        {
            return base.Update(entity);
        }

        public IDataResult<Car> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_entityDal.Get(c => c.BrandId == brandId));
        }

        public IDataResult<Car> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_entityDal.Get(c => c.ColorId == colorId));

        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_entityDal.Get(c => c.Id == id));

        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_entityDal.GetCarDetail());
        }

        
    }
}