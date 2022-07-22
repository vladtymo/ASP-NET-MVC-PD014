using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public enum Categories : int
    {
        Fashion = 1,
        Electronics,
        Art,
        Musical,
        HomeAndGarder,
        AutoParts,
        Sport,
        ToysAndHobbies
    }
    public class Category
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}