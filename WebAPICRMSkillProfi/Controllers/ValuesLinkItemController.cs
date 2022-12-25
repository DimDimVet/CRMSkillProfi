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
    public class ValuesLinkItemController : Controller
    {
        private IValuesModelRepozitory<LinkItem> _linkRepozitory;
        public ValuesLinkItemController(IValuesModelRepozitory<LinkItem> linkRepozitory)
        {
            this._linkRepozitory = linkRepozitory;
        }
        #region Link

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListLink")]
        public ActionResult<string> GetListLink()
        {
            IEnumerable<LinkItem> _listContact = _linkRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listContact, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewLink")]
        public ActionResult<LinkItem> PostNewLink(LinkItem _link)
        {
            if (_link == null)
            {
                return BadRequest();
            }
            _linkRepozitory.AddAsync(_link);
            return Ok(_link);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditLink")]
        public ActionResult<LinkItem> PutEditLink(LinkItem _link)
        {
            if (_link == null)
            {
                return BadRequest();
            }
            _linkRepozitory.EditAsync(_link.Id, _link);
            return Ok(_link);
        }

        [HttpDelete("DeleteLink/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteLink(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _linkRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
