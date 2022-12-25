using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesContactItemController : Controller
    {
        private IValuesModelRepozitory<ContactItem> _contactRepozitory;
        public ValuesContactItemController(IValuesModelRepozitory<ContactItem> contactRepozitory)
        {
            this._contactRepozitory = contactRepozitory;
        }
        #region Contact

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListContact")]
        public ActionResult<string> GetListContact()
        {
            IEnumerable<ContactItem> _listContact = _contactRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listContact, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewContact")]
        public ActionResult<ContactItem> PostNewContact(ContactItem _contact)
        {
            if (_contact == null)
            {
                return BadRequest();
            }
            _contactRepozitory.AddAsync(_contact);
            return Ok(_contact);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditContact")]
        public ActionResult<ContactItem> PutEditContact(ContactItem _contact)
        {
            if (_contact == null)
            {
                return BadRequest();
            }
            _contactRepozitory.EditAsync(_contact.Id, _contact);
            return Ok(_contact);
        }

        [HttpDelete("DeleteContact/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteContact(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _contactRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
