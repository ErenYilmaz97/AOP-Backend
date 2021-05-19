using Core.DataAccess.EntityFramework;
using Entities.Entities;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        
    }
}