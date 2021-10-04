using Business.Abstract;
using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : BaseService<IRentalDal, Rental>, IRentalService
    {
        public RentalManager(IRentalDal entityDal) : base(entityDal) { }

        public override IResult Add(Rental entity)
        {
            
            var result = _entityDal.GetAll(r => r.CarId == entity.CarId && !r.ReturnDate.HasValue);

            if (!result.Any())
            {
                return base.Add(entity);
            }

            return new ErrorDataResult<Rental>();
        }

        public override IResult Delete(Rental entity)
        {
            return base.Delete(entity);
        }

        public override IDataResult<List<Rental>> GetAll()
        {
            return base.GetAll();
        }

        public override IDataResult<Rental> Update(Rental entity)
        {
            return base.Update(entity);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_entityDal.Get(r => r.Id == id));
        }
    }
}
