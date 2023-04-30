using DAL.Interfaces;
using DAL.ModelA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.RepoA
{
    internal class CategoryRepo : Repo, InRepo<Category, int, bool>
    {
        public bool Delete(int id)
        {
            // throw new NotImplementedException();
            var ex = Get(id);
            db.Categories.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public Category Insert(Category obj)
        {
            db.Categories.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public Category Update(Category obj)
        {
            var ex = Get(obj.CategoryId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
