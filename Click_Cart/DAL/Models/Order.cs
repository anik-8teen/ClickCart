using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateOrdered { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Order ()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
