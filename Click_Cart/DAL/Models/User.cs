using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Wishlist> Wishlists { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public User()
        {
            Wishlists = new List<Wishlist>();
            Reviews = new List<Review>();
            Orders= new List<Order>();


        }

    }

}
