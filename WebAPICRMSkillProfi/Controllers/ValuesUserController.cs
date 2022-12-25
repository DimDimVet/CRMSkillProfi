using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesUserController : Controller
    {
        private IValuesModelRepozitory<User> _userRepozitory;
        public ValuesUserController(IValuesModelRepozitory<User> userRepozitory)
        {
            this._userRepozitory = userRepozitory;
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListUser")]
        public ActionResult<string> GetNameLogin()
        {
            IEnumerable<User> _listUser = _userRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listUser, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        [Route("PostNewUser")]
        public ActionResult<User> PostNewAccountUser(User _user)
        {
            if (_user == null)
            {
                return BadRequest();
            }
            _userRepozitory.AddAsync(_user);
             return Ok(_user);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditUser")]
        public ActionResult<User> Put(User _user)
        {
            if (_user == null)
            {
                return BadRequest();
            }
            _userRepozitory.EditAsync(_user.Id, _user);
            return Ok(_user);
        }

        [HttpDelete("DeleteUser/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteUser(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _userRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
    }
}
