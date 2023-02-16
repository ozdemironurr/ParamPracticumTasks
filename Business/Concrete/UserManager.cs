using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
       private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
           
           _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
              
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll().OrderBy(u=>u.UserName).ToList(), Messages.UsersListed);
           
        }

        public IDataResult<User> GetById(int userId)
        {
            var result= new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
            if (result.Data.UserId==null)
            {
                return new ErrorDataResult<User>(Messages.WrongIdEntry);
            }
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId==userId), Messages.UsersListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
