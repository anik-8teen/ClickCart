using DAL.Interfaces;
using DAL.ModelA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepoA
{
    internal class SellerRepo : Repo, InRepo<Seller, int, bool>

    {
        public bool Delete(int id)
        {
            //throw new NotImplementedException();
            var ex = Get(id);
            db.Sellers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Seller> Get()
        {
            //throw new NotImplementedException();
            return db.Sellers.ToList();
        }

        public Seller Get(int id)
        {
            //throw new NotImplementedException();
            return db.Sellers.Find(id);
        }

        public Seller Insert(Seller obj)
        {
            db.Sellers.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Seller Update(Seller obj)
        {
            // throw new NotImplementedException();
            var ex = Get(obj.SellerId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
