using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Game
    {
        public Game()
        {
            Categories = new HashSet<Category>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
