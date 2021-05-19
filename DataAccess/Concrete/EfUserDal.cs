using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepository<User, CampAuthDbContext>, IUserDal
    {

        public List<OperationClaim> GetUserClaims(User user)
        {
            
            using(var _context = new CampAuthDbContext())
            {

                return _context.Users.Include(x=>x.OperationClaims).FirstOrDefault(x=>x.Id == user.Id).OperationClaims;

            }

        }
    }
}
