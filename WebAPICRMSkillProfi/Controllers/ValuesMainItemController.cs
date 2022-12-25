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
    public class ValuesMainItemController : Controller
    {
        private IValuesModelRepozitory<MainItem> _mainRepozitory;
        public ValuesMainItemController(IValuesModelRepozitory<MainItem> mainRepozitory)
        {
            this._mainRepozitory = mainRepozitory;
        }
        #region main

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("GetListMain")]
        public ActionResult<string> GetListMain()
        {
            IEnumerable<MainItem> _listBlog = _mainRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listBlog, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewMain")]
        public ActionResult<ProjectItem> PostNewMain(MainItem _main)
        {
            if (_main == null)
            {
                return BadRequest();
            }
            _mainRepozitory.AddAsync(_main);
            return Ok(_main);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditMain")]
        public ActionResult<MainItem> PutEditMain(MainItem _main)
        {
            if (_main == null)
            {
                return BadRequest();
            }
            _mainRepozitory.EditAsync(_main.Id, _main);
            return Ok(_main);
        }

        [HttpDelete("DeleteMain/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteMain(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _mainRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
