using Microsoft.AspNetCore.Mvc;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ContactIndex()
        {
            if (Logic.ControlApi())
            {
                return View(Logic.LoadContactResurs());
            }
            else
            {
                return Redirect("~/Home/Index");
            }
            
        }
    }
}
