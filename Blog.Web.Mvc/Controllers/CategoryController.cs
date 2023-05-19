using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [Route("/category/{slug}", Name = "CategorySlug")]
        public IActionResult Index(string slug)
        {
            var categoryNames = _context.Categories.Include(e => e.Posts).ToList();
            ViewBag.CategoryNames = categoryNames;

            var posts = _context.Posts
                .Include(p => p.Category)
                .Where(e => e.Category.Slug == slug)
                .ToList();

            var category = _context.Categories.Where(e => e.Slug == slug).FirstOrDefault();
            ViewBag.CategoryName = category.Name;

            return View(posts);
        }



    }
}

