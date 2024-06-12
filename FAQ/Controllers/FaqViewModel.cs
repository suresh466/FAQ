using FAQ.Models;

public class FaqViewModel
{
    public List<Question> Questions { get; set; }
    public List<Topic> Topics { get; set; }
    public List<Category> Categories { get; set; }
    public string ActiveTopic { get; set; } = "all";
    public string ActiveCategory { get; set; } = "all";
}
