using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Components;

public class NavbarViewComponent : ViewComponent
{
    private AppDbContext db { get; set; }
    public NavbarViewComponent(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    
    { 
        return View(db.Categories.ToList()); 
    
    }

	
}
