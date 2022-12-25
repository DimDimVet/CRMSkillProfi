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
    public class ValuesServiceItemController : Controller
    {
        private IValuesModelRepozitory<ServiceItem> _serviceRepozitory;
        public ValuesServiceItemController(IValuesModelRepozitory<ServiceItem> serviceRepozitory)
        {
            this._serviceRepozitory = serviceRepozitory;
        }
        #region service

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListService")]
        public ActionResult<string> GetListService()
        {
            IEnumerable<ServiceItem> _listService = _serviceRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listService, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewService")]
        public ActionResult<ServiceItem> PostNewService(ServiceItem _service)
        {
            if (_service == null)
            {
                return BadRequest();
            }
            _serviceRepozitory.AddAsync(_service);
            return Ok(_service);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditService")]
        public ActionResult<ServiceItem> PutEditService(ServiceItem _service)
        {
            if (_service == null)
            {
                return BadRequest();
            }
            _serviceRepozitory.EditAsync(_service.Id, _service);
            return Ok(_service);
        }

        [HttpDelete("DeleteService/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteService(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _serviceRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
