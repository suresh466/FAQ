using System.Collections.Generic;

namespace FAQ.Models
{
    public class FaqViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
        public IEnumerable<Topic> Topics { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}