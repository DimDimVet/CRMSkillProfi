using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesMessangeRepozitory : IValuesModelRepozitory<Messange>
    {
        private DbSqlContext _dbContext;
        private EventRepozitory _eventMessange;
        public ValuesMessangeRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
            _eventMessange = new EventRepozitory();
        }

        #region Messange
        public async Task<IEnumerable<Messange>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Messanges;
        }
        public async Task AddAsync(Messange _messange)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Messanges.AddAsync(_messange);
                await _dbContext.SaveChangesAsync();
            }
            for (int i = 0; i < Option.Users.Count; i++)
            {
                if (_messange.EmailSender == Option.Users[i].UserName)
                {
                    await _eventMessange.EventMessange(_messange);
                }
            }
            
        }
        public async Task EditAsync(string _idOldMessange, Messange _messangeEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<Messange> _temp = _dbContext.Messanges.Where(m => m.Id == $"{_idOldMessange}");
                foreach (Messange item in _temp)
                {
                    item.Id = _messangeEdit.Id;
                    item.TimeRequest = _messangeEdit.TimeRequest;
                    item.TextMessange = _messangeEdit.TextMessange;
                    item.LastTextMessange = _messangeEdit.LastTextMessange;
                    item.EmailSender = _messangeEdit.EmailSender;
                    item.UserRecipientMess = _messangeEdit.UserRecipientMess;
                }
                await _dbContext.SaveChangesAsync();
            }
            for (int i = 0; i < Option.Users.Count; i++)
            {
                if (_messangeEdit.EmailSender == Option.Users[i].UserName)
                {
                    await _eventMessange.EventMessange(_messangeEdit);
                }
            }
        }
        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<Messange> _temp = _dbContext.Messanges.Where(p => p.Id == $"{_id}");
                foreach (Messange item in _temp)
                {
                    _dbContext.Messanges.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
