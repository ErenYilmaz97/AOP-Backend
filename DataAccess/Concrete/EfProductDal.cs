using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DbContext;
using System.Collections.Generic;
using System.Linq;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepository<Product, CampAuthDbContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {

            using (var _context = new CampAuthDbContext())
            {
                return _context.Products.Include(x => x.Category).Select(x => new ProductDetailDto()
                {
                    ProductId = x.Id,
                    ProductName = x.Name,
                    CategoryName = x.Category.Name,
                    UnitsInStock = x.UnitsInStock
                }).ToList();
            }

            
        }
    }
}