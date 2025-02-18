﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Performance;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;



        //DI
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [PerformanceAspect(5)]
        [CacheRemoveAspect("IProductService.Get")]
        [LogAspect(typeof(FileLogger))]
        [LogAspect(typeof(DatabaseLogger))]


        public IResult Add(Product product)
        {

            //Aynı isimde ürün eklenemez
            //Eğer mevcut kategori sayısı 15'i geçtiyse sisteme yeni ürün eklenemez. ve 
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.Name),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);

        }


        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }




        [CacheAspect]
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }



        
        //[CacheAspect]
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        public IDataResult<Product> GetById(int productId)
        {
            throw new AuthenticationException("Unauthorized.");
            //return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }




        [CacheAspect]
        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }




        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }





        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }



        [ValidationAspect(typeof(ProductValidator))]
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {

            _productDal.Add(product);
            if (product.UnitPrice < 50)
            {
                //BURAYA DÜŞÜP HATA OLUŞURSA, YUKARIDAKİ İŞLEMİN GERİ ALINMASI GEREKİR.
                throw new Exception("");
            }

            _productDal.Add(new Product()
            {
                //AYNI NESNEYİ TEKRAR EKLE
                Name = product.Name,
                CategoryId = product.CategoryId, 
                UnitPrice = product.UnitPrice, 
                UnitsInStock = product.UnitsInStock
            });

            return new SuccessResult();
        }





        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //Select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }





        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.Name == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }





        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }

            return new SuccessResult();
        }

    }
}

