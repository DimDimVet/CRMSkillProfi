using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesLinkRepozitory : IValuesModelRepozitory<LinkItem>
    {
        private DbSqlContext _dbContext;
        public ValuesLinkRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region Link
        public async Task<IEnumerable<LinkItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Links;
        }
        public async Task AddAsync(LinkItem _link)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Links.AddAsync(_link);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task EditAsync(string _idOldLink, LinkItem _linkEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<LinkItem> _temp = _dbContext.Links.Where(m => m.Id == $"{_idOldLink}");
                foreach (LinkItem item in _temp)
                {
                    item.Id = _linkEdit.Id;
                    item.Url = _linkEdit.Url;
                    item.Data = _linkEdit.Data;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<LinkItem> _temp = _dbContext.Links.Where(p => p.Id == $"{_id}");
                foreach (LinkItem item in _temp)
                {
                    _dbContext.Links.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
