using Microsoft.AspNetCore.Mvc;
using FAQ.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Controllers
{
    public class HomeController : Controller
    {
        private FaqDbContext _context;

        public HomeController(FaqDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string topic = "all", string category = "all")
        {
            var viewModel = new FaqViewModel
            {
                ActiveTopic = topic,
                ActiveCategory = category,
                Topics = _context.Topics.ToList(),
                Categories = _context.Categories.ToList()
            };

            IQueryable<Question> query = _context.Questions;
            if (topic != "all")
                query = query.Where(q => q.Topic.Name.ToLower() == topic.ToLower());
            if (category != "all")
                query = query.Where(q => q.Category.Name.ToLower() == category.ToLower());
            viewModel.Questions = query.ToList();

            return View(viewModel);
        }
    }

}