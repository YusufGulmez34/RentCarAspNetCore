using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Abstracts;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : BaseService<IUserDal, User>, IUserService
    {
        public UserManager(IUserDal entityDal) : base(entityDal) { }

        public override IResult Add(User entity)
        {
            return base.Add(entity);
        }

        public override IResult Delete(User entity)
        {
            return base.Delete(entity);
        }

        public override IDataResult<List<User>> GetAll()
        {
            return base.GetAll();
        }

        public override IDataResult<User> Update(User entity)
        {
            return base.Update(entity);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_entityDal.Get(u => u.Id == id));
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _entityDal.GetClaims(user);

        }

        public User GetByMail(string email)
        {
            return _entityDal.Get(u => u.Email == email);
        }
    }
}
