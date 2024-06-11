using Microsoft.AspNetCore.Mvc;
using FAQ.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly FaqDbContext _context;

        public HomeController(FaqDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string topic = null, string category = null)
        {
            var questions = _context.Questions
                .Include(q => q.Topic)
                .Include(q => q.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(topic))
            {
                questions = questions.Where(q => q.Topic.Name == topic);
            }

            if (!string.IsNullOrEmpty(category))
            {
                questions = questions.Where(q => q.Category.Name == category);
            }

            var viewModel = new FaqViewModel
            {
                Questions = questions.ToList(),
                Topics = _context.Topics.ToList(),
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }
    }
}