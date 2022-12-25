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
    
    public class ValuesProjectItemController : Controller
    {
        private IValuesModelRepozitory<ProjectItem> _projectRepozitory;
        public ValuesProjectItemController(IValuesModelRepozitory<ProjectItem> projectRepozitory)
        {
            this._projectRepozitory = projectRepozitory;
        }
        #region project

        [HttpGet]
        [Authorize(Roles = "admin, user")]
        [Route("GetListProject")]
        public ActionResult<string> GetListProject()
        {
            IEnumerable<ProjectItem> _listProject = _projectRepozitory.GetListAsync().Result;
            string _json = JsonConvert.SerializeObject(_listProject, Formatting.Indented);
            return Ok(_json);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("PostNewProject")]
        public ActionResult<ProjectItem> PostNewProject(ProjectItem _project)
        {
            if (_project == null)
            {
                return BadRequest();
            }
            _projectRepozitory.AddAsync(_project);
            return Ok(_project);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("PutEditProject")]
        public ActionResult<ProjectItem> PutEditProject(ProjectItem _project)
        {
            if (_project == null)
            {
                return BadRequest();
            }
            _projectRepozitory.EditAsync(_project.Id, _project);
            return Ok(_project);
        }

        [HttpDelete("DeleteProject/{_id}")]
        [Authorize(Roles = "admin")]
        public ActionResult<bool> DeleteProject(string _id)
        {
            if (_id == null)
            {
                return BadRequest();
            }
            _projectRepozitory.DeleteAsync(_id);
            return Ok(true);
        }
        #endregion
    }
}
