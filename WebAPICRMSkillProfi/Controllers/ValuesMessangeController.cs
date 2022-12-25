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
    public class ValuesMessangeController : Controller
    {
        private IValuesModelRepozitory<Messange> _messangeRepozitory;
        private IValuesModelRepozitory<User> _userRepozitory;
        public ValuesMessangeController(IValuesModelRepozitory<Messange> messangeRepozitory, IValuesModelRepozitory<User> userRepozitory)
        {
            this._messangeRepozitory = messangeRepozitory;
            this._userRepozitory = userRepozitory;
            Option.AdminUserList(_userRepozitory.GetListAsync().Result);
        }

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListMessange")]
        public ActionResult<string> GetMessange()
        {
            IEnumerable<Messange> _listUser = _messangeRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listUser, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin, user")]
        [Route("PostNewMessange")]
        public ActionResult<Messange> PostNewMessange(Messange _messange)
        {
            if (_messange == null)
            {
                return BadRequest();
            }
            _messangeRepozitory.AddAsync(_messange);
            return Ok(_messange);
        }

        [HttpPut]
        [Authorize(Roles = "admin, user")]
        [Route("PutEditMessange")]
        public ActionResult<Messange> Put(Messange _messange)
        {
            if (_messange == null)
            {
                return BadRequest();
            }
            _messangeRepozitory.EditAsync(_messange.Id, _messange);
            return Ok(_messange);
        }

        [HttpDelete("DeleteMess/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteMessange(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _messangeRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
    }
}
