using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Controllers
{
    public class AccountController : Controller
    {
        private DbSqlContext _dbUser;
        private TokenGenerator _generToken;
        private User _currentUser;

        [HttpPost("/token")]
        public IActionResult GetIdentity(string username, string email)
        {
            _dbUser = new DbSqlContext();
            _currentUser = _dbUser.Users.FirstOrDefault(u => 
                            u.UserName == username && u.Email == email);
            if (_currentUser != null)
            {
                _generToken = new TokenGenerator();
                return Json( _generToken.Token(_currentUser));
            }
            else
            {
                return null;
            }
        }
    }
}
