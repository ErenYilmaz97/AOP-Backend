using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Entities;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
    }
}