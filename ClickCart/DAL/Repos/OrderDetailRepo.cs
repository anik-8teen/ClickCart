using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class OrderDetailRepo : Repo, IRepo<OrderDetail, int, bool>
    {
        public List<OrderDetail> Get()
        {
            return db.OrderDetails.ToList();
        }

        public OrderDetail Get(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public bool Insert(OrderDetail obj)
        {
            db.OrderDetails.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(OrderDetail obj)
        {
            var exst = db.OrderDetails.Find(obj.Id);
            if (exst != null)
            {
                db.Entry(exst).CurrentValues.SetValues(obj);
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var data = db.OrderDetails.Find(id);
            if (data != null)
            {
                db.OrderDetails.Remove(data);
                return db.SaveChanges() > 0;
            }
            return false;
        }
    }
}
