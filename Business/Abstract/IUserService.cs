using Core.Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        IDataResult<User> GetById(int id);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
