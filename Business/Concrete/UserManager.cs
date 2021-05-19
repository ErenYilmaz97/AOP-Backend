using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using Business.Constants;
using DataAccess.Abstract;


namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;


        //DI
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }




        public IResult Add(User user)
        {
            _userDal.Add(user);
            
            return new SuccessResult(Messages.UserAdded);
        }




        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.Email == email));
        }




        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetUserClaims(user));
        }
    }
}