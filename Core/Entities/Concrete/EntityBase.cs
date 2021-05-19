using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }



        public EntityBase()
        {
            this.Created = DateTime.Now;
            this.IsDeleted = false;
        }

       
    }
}
