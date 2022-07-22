using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public enum Roles : int
    {
        User = 1,
        Manager,
        Moderator,
        Administrator
    }
    public class Role
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}