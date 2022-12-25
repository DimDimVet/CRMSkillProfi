using Microsoft.AspNetCore.Mvc;
using WebCRMSkillProfi.Interfaces;
using WebCRMSkillProfi.Models;
using WebCRMSkillProfi.ViewModels;

namespace WebCRMSkillProfi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (Logic.ControlApi())
            {
                return View(Logic.LoadHomeResurs());
            }
            else
            {
                return View("ErrorApi");
            }

        }

        [HttpPost]
        public IActionResult InChatUser(string _UserName, string _Email)
        {
            IUser _testUser = new User { UserName = _UserName, Email = _Email };
            IUser _controlResult = Logic.ControlUser(_testUser).Result;
            if (_controlResult != null)
            {
                return Redirect($"~/Home/ChatPage?_UserName={_controlResult.UserName}&_Email={_controlResult.Email}");
            }
            else
            {
                return Redirect("~/Home/Index");
            }
        }

        [HttpGet]
        public IActionResult ChatPage(string _UserName, string _Email)
        {
            IUser _testUser = new User { UserName = _UserName, Email = _Email };
            IUser _conkretUser = Logic.ControlUser(_testUser).Result;

            ChatViewModel viewModel = Logic.PersonChat(_conkretUser);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddMessange(ChatViewModel _model)
        {
            Logic.SaveMessange(_model);
            return Redirect($"~/Home/ChatPage?_UserName={_model._User.UserName}&_Email={_model._User.Email}");
        }
    }
}
