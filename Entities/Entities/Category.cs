using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Entities
{
    public class Category : EntityBase<int>, ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }


        public List<Product> Products { get; set; }


        public Category():base()
        {
            
        }
    }
}