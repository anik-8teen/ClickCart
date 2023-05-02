using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>
    {
        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Insert(Customer obj)
        {
            db.Customers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Customer obj)
        {
            var exst = db.Customers.Find(obj.CustomerId);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var data = db.Customers.Find(id);
            if (data != null)
            {
                db.Customers.Remove(data);
                return db.SaveChanges() > 0;
            }
            return false;
        }

    }
}
