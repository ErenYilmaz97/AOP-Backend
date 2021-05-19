using System;
using System.ComponentModel;
using Entities.Entities;

namespace Core.Entities.Concrete
{
    public class Product : EntityBase<int>, ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; }

        public Category Category { get; set; }


        public Product():base()
        {
            
        }

        
    }
}