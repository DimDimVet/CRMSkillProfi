using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesContactRepozitory : IValuesModelRepozitory<ContactItem>
    {
        private DbSqlContext _dbContext;
        public ValuesContactRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region Contact
        public async Task<IEnumerable<ContactItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Contacts;
        }
        public async Task AddAsync(ContactItem _contact)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Contacts.AddAsync(_contact);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task EditAsync(string _idOldContact, ContactItem _contactEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ContactItem> _temp = _dbContext.Contacts.Where(m => m.Id == $"{_idOldContact}");
                foreach (ContactItem item in _temp)
                {
                    item.Id = _contactEdit.Id;
                    item.TextContactA = _contactEdit.TextContactA;
                    item.TextContactB = _contactEdit.TextContactB;
                    item.TextContactC = _contactEdit.TextContactC;
                    item.Data = _contactEdit.Data;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<ContactItem> _temp = _dbContext.Contacts.Where(p => p.Id == $"{_id}");
                foreach (ContactItem item in _temp)
                {
                    _dbContext.Contacts.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
