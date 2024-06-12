using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAQ.Models
{
    public class Question
    {
        // unique id is generated automatically be the database
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string Answer { get; set; }

        // Each question is associated with a topic
        [Required]
        [ForeignKey("Topic")]
        public string TopicId { get; set; }
        public Topic Topic { get; set; }

        // Each question is associated with a category
        [Required]
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}