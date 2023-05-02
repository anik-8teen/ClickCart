using DAL.Interfaces;
using DAL.ModelA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepoA
{
    internal class ProductRepo : Repo, InRepo<Product, int, bool>
    {
        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Products.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            // throw new NotImplementedException();
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            //  throw new NotImplementedException();
            return db.Products.Find(id);
        }

        public Product Insert(Product obj)
        {
            db.Products.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Product Update(Product obj)
        {
            var ex = Get(obj.ProductId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
