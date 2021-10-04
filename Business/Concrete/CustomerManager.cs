using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business.Abstract;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : BaseService<ICustomerDal, Customer>, ICustomerService
    {
        public CustomerManager(ICustomerDal entityDal) : base(entityDal)
        {
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public override IResult Add(Customer entity)
        {
            return base.Add(entity);
        }

        public override IResult Delete(Customer entity)
        {
            return base.Delete(entity);
        }

        public override IDataResult<List<Customer>> GetAll()
        {
            return base.GetAll();
        }

        public override IDataResult<Customer> Update(Customer entity)
        {
            return base.Update(entity);
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>( _entityDal.Get(c => c.Id == id));
        }
    }
}
