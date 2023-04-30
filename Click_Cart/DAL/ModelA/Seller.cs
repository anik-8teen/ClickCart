using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ModelA
{
    class Seller
    {
        
    [Key]
        public int SellerId { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string SellerContact { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    
}

   
}
