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
        public string ProductName { get; set; }

        [Required]
      
        public decimal Price { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        
        public virtual Category Category { get; set; }

        [Required]
        [ForeignKey("SellerId")]
        public int SellerId { get; set; }

       
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