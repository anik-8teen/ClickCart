using DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int? Price { get; set; }
        public int Qty { get; set; }
        [ForeignKey("Category")]
        public int CId { get; set; }


        [ForeignKey("Seller")]
        public int SId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; }


        public Product()
        {
            Reviews = new List<Review>();
            Wishlists = new List<Wishlist>();
        }

        


    }
}