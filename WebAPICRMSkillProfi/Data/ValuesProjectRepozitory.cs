using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesProjectRepozitory : IValuesModelRepozitory<ProjectItem>
    {
        private DbSqlContext _dbContext;
        public ValuesProjectRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region Project
        public async Task<IEnumerable<ProjectItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Projects;
        }
        public async Task AddAsync(ProjectItem _project)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Projects.AddAsync(_project);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task EditAsync(string _idOldProject, ProjectItem _projectEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ProjectItem> _temp = _dbContext.Projects.Where(m => m.Id == $"{_idOldProject}");
                foreach (ProjectItem item in _temp)
                {
                    item.Id = _projectEdit.Id;
                    item.Title = _projectEdit.Title;
                    item.Desription = _projectEdit.Desription;
                    item.Data = _projectEdit.Data;
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ProjectItem> _temp = _dbContext.Projects.Where(p => p.Id == $"{_id}");
                foreach (ProjectItem item in _temp)
                {
                    _dbContext.Projects.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        #endregion
    }
}
