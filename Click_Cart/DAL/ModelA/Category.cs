using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.ModelA
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}