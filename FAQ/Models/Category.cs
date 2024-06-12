using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class Category
    {
        // id is the string as required by the specs of the assignment
        [Key]
        public string Name { get; set; }
        // Each category can have many questions
        public ICollection<Question> Questions { get; set; }
    }
}