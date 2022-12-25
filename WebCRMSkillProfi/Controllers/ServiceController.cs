using Microsoft.AspNetCore.Mvc;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult ServiceIndex()
        {
            if (Logic.ControlApi())
            {
                return View(Logic.LoadServiceResurs());
            }
            else
            {
                return Redirect("~/Home/Index");
            }
            
        }
    }
}
