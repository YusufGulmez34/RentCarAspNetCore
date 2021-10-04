using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepository<Brand, RentCarDbContext>, IBrandDal
    {
    }
}
