using Microsoft.AspNetCore.Mvc;
using FAQ.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Controllers
{
    public class HomeController : Controller
    {
        private FaqDbContext _context;

        // The context is provided to the controller via dependency injection
        public HomeController(FaqDbContext context)
        {
            _context = context;
        }

        // This is the action for the home page
        public IActionResult Index(string topic = "all", string category = "all")
        {
            // We create a view model to hold the data we need for the view
            var viewModel = new FaqViewModel
            {
                ActiveTopic = topic,
                ActiveCategory = category,
                Topics = _context.Topics.ToList(),
                Categories = _context.Categories.ToList()
            };

            // We get the questions from the database
            IQueryable<Question> query = _context.Questions;
            // If a specific topic or category is selected, we filter the questions
            if (topic != "all")
                query = query.Where(q => q.Topic.Name.ToLower() == topic.ToLower());
            if (category != "all")
                query = query.Where(q => q.Category.Name.ToLower() == category.ToLower());
            viewModel.Questions = query.ToList();

            // We pass the view model to the view
            return View(viewModel);
        }
    }

}