using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Web.Mvc.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Web.Mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Search(string query, int? page)
        {
            var categoryNames = _context.Categories.Include(e => e.Posts).ToList();
            ViewBag.CategoryNames = categoryNames;

            var posts = _context.Posts
                .Include(e => e.Category)
                .Select(e => e);

            if (query != null) posts = posts.Where(e => e.Content.Contains(query) || e.Title.Contains(query));

            var postList = posts.ToList();

            return View(postList);
        }

        public IActionResult Detail(int id)
        {
            var categoryNames = _context.Categories.Include(e => e.Posts).ToList();
            ViewBag.CategoryNames = categoryNames;

            var post = _context.Posts
                .Include(e => e.Category)
                .Include(e => e.PostImage)
                .Where(e => e.Id == id)
                .FirstOrDefault();

            ViewBag.PostComments = _context.PostComments
                .Include(e => e.User)
                .Where(e => e.PostId == id)
                .ToList();

            var userId = _context.Posts.Where(e => e.Id == id).FirstOrDefault().UserId;
            ViewBag.User = _context.Users.Where(e => e.Id == userId).FirstOrDefault();

            ViewBag.NextPost = _context.Posts.OrderBy(e => e.Id).Where(e => e.Id > id).FirstOrDefault();
            ViewBag.PreviousPost = _context.Posts.OrderBy(e => e.Id).Where(e => e.Id < id).LastOrDefault();

            return View(post);
        }
    }
}

