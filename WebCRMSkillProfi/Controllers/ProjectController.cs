using Microsoft.AspNetCore.Mvc;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult ProjectIndex()
        {
            if (Logic.ControlApi())
            {
                return View(Logic.LoadProjectResurs());
            }
            else
            {
                return Redirect("~/Home/Index");
            }

        }
        public IActionResult ProjectItem(string GetId)
        {
            return View(Logic.OpenProjectItem(GetId));
        }
    }
}
