using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL.Models
{
    public class Seller
    {

        [Key]
        public int Id { get; set; }
        [Required]  
        public string CompanyName { get; set; }

        [Required]
        public string SellerContact { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public Seller()
        {

            Products = new List<Product>();
        }




    }
}
