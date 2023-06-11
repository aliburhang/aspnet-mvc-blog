using App.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Mvc.Components;

public class SliderViewComponent : ViewComponent
{
    private AppDbContext db { get; set; }
    public SliderViewComponent(AppDbContext db)
    {
        this.db = db;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    
    { 
        return View(db.Posts.ToList()); 
    
    }

	
}
