using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        [ForeignKey("Product")]
        public int PId { get; set; }


        [ForeignKey("User")]
        public string UId { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }

       
    }

}
