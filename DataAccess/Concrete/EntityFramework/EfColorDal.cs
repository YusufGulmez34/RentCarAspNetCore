using Core.DataAccess.EntityFramework.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepository<Color, RentCarDbContext>, IColorDal
    {
    }
}
