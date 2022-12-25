using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Models;
using WebAPICRMSkillProfi.Interface;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesServiceRepozitory : IValuesModelRepozitory<ServiceItem>
    {
        private DbSqlContext _dbContext;
        public ValuesServiceRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region Service
        public async Task<IEnumerable<ServiceItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Service;
        }

        public async Task AddAsync(ServiceItem _service)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Service.AddAsync(_service);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(string _idOldService, ServiceItem _serviceEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ServiceItem> _temp = _dbContext.Service.Where(m => m.Id == $"{_idOldService}");
                foreach (ServiceItem item in _temp)
                {
                    item.Id = _serviceEdit.Id;
                    item.TitleService = _serviceEdit.TitleService;
                    item.DesriptionService = _serviceEdit.DesriptionService;
                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ServiceItem> _temp = _dbContext.Service.Where(p => p.Id == $"{_id}");
                foreach (ServiceItem item in _temp)
                {
                    _dbContext.Service.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
