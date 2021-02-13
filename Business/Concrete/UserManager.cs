﻿using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager
    {
        IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public IResult Add(User User)
        {
            _userDAL.Add(User);
            return new SuccessResult();
        }
        public IResult Delete(User User)
        {
            _userDAL.Delete(User);
            return new SuccessResult();
        }
        public IResult Update(User User)
        {
            _userDAL.Update(User);
            return new SuccessResult();
        }
        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_userDAL.GetAll());
        }
        public IDataResult<User> GetById(User User)
        {
            return new SuccessDataResult<User>(_userDAL.Get(c => c.Id == User.Id));
        }
    }
}
