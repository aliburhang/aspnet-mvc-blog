using Blog.Web.Mvc.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Components;

public class ArticleViewComponent : ViewComponent
{
    private AppDbContext db { get; set; }
    public ArticleViewComponent(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    
    { 
        return View(db.Categories.ToList()); 
    
    }

	
}
