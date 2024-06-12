using FAQ.Models;

public class FaqViewModel
{
    // Lists to hold our questions, topics, and categories
    public List<Question> Questions { get; set; }
    public List<Topic> Topics { get; set; }
    public List<Category> Categories { get; set; }

    // Track the currently selected topic and category
    public string ActiveTopic { get; set; } = "all";
    public string ActiveCategory { get; set; } = "all";
}
