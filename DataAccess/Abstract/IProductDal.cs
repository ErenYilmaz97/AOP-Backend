using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}