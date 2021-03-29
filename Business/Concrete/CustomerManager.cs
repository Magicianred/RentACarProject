﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using Business.BusinessAspect.Autofac;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDAL _customerDAL; 
        public CustomerManager(ICustomerDAL customerDAL)
        {
            _customerDAL = customerDAL;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDAL.Add(customer);
            return new SuccessResult();
        }

        [SecuredOperation("customers.add,admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customer customer)
        {
            _customerDAL.Delete(customer);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDAL.Update(customer);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDAL.GetAll());
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDAL.Get(c => c.Id == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDAL.GetCustomerDetailDto());
        }

    }
}
