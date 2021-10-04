using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : BaseService<IColorDal, Color>, IColorService
    {
        public ColorManager(IColorDal entityDal) : base(entityDal) { }

        [SecuredOperation("admin")]
        public override IResult Add(Color entity)
        {
            return base.Add(entity);
        }

        public override IResult Delete(Color entity)
        {
            return base.Delete(entity);
        }

        public override IDataResult<List<Color>> GetAll()
        {
            return base.GetAll();
        }

        public Color GetById(int id)
        {
            return _entityDal.Get(c => c.Id == id);
        }

        public override IDataResult<Color> Update(Color entity)
        {
            return base.Update(entity);
        }
    }
}
