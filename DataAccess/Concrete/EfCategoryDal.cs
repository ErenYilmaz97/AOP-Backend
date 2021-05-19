using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DbContext;
using Entities.Entities;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepository<Category,CampAuthDbContext>, ICategoryDal
    {
        
    }
}