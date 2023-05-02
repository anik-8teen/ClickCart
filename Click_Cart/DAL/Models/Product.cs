using DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Seller")]
        public int SellerId { get; set; }

        [ForeignKey("SellerId")]
        public virtual Seller Seller { get; set; }

        public virtual ICollection<Seller> Sellers { get; set; }
        public Product()
        {

            Sellers = new List<Seller>();
        }


    }
}