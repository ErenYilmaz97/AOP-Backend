using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class User : EntityBase<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string Lastname  { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }


        public virtual List<OperationClaim> OperationClaims { get; set; }


        public User():base()
        {
            OperationClaims = new List<OperationClaim>();
        }
    }
}
