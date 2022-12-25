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
    public class ValuesBlogItemController : Controller
    {
        private IValuesModelRepozitory<BlogItem> _blogRepozitory;
        public ValuesBlogItemController(IValuesModelRepozitory<BlogItem> blogRepozitory)
        {
            this._blogRepozitory = blogRepozitory;
        }
        #region blog

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListBlog")]
        public ActionResult<string> GetListBlog()
        {
            IEnumerable<BlogItem> _listBlog = _blogRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listBlog, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewBlog")]
        public ActionResult<BlogItem> PostNewBlog(BlogItem _blog)
        {
            if (_blog == null)
            {
                return BadRequest();
            }
            _blogRepozitory.AddAsync(_blog);
            return Ok(_blog);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditBlog")]
        public ActionResult<BlogItem> PutEditBlog(BlogItem _blog)
        {
            if (_blog == null)
            {
                return BadRequest();
            }
            _blogRepozitory.EditAsync(_blog.Id, _blog);
            return Ok(_blog);
        }

        [HttpDelete("DeleteBlog/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteBlog(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _blogRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
