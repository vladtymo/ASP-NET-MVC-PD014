using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [MinLength(10), MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        //[Range(1, 10)]
        public float Rating { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
