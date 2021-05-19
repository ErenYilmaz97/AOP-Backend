using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EfDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            //SİLİNECEK OLARAK İŞARETLENEN ENTİTYLERİ BUL
            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);


            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is ISoftDeletable entity)
                {
                    /*NORMAL UPDATE YAPILDIĞINDA, TÜM ENTİTY MODIFIED OLARAK İŞARETLENİR, DBYE NESNENİN TAMAMI GÖNDERİLİR DEĞİŞMİŞ ALANLAR GÜNCELLENİR.
                    BURADA ENTİTYİ UNCHANGED OLARAK AYARLAYIP ARDINDAN ISDELETE ALANINI DEĞİŞTİREREK, GÜNCELLEME İFADESİNİ İSDELETE ALANI İLE SINIRLADIK.  */
                    item.State = EntityState.Unchanged;
                    entity.IsDeleted = true;
                }
            }

            return base.SaveChanges();
        }
    }
}
