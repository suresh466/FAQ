using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class Category
    {
        [Key]
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}