using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public bool Insert(Product obj)
        {
            db.Products.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Product obj)
        {
            var exst = db.Products.Find(obj.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var data = db.Products.Find(id);
            if (data != null)
            {
                db.Products.Remove(data);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
