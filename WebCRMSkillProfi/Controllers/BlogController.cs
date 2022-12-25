using Microsoft.AspNetCore.Mvc;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogIndex()
        {
            if (Logic.ControlApi())
            {
                return View(Logic.LoadBlogResurs());
            }
            else
            {
                return Redirect("~/Home/Index");
            }
            
        }
        public IActionResult BlogItem(string GetId)
        {
            return View(Logic.OpenBlogtem(GetId));
        }
    }
}
