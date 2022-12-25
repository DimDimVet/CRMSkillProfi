using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesMainRepozitory : IValuesModelRepozitory<MainItem>
    {
        private DbSqlContext _dbContext;
        public ValuesMainRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region main
        public async Task<IEnumerable<MainItem>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Mains;
        }
        public async Task AddAsync(MainItem _main)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Mains.AddAsync(_main);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(string _idOldMain, MainItem _mainEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<MainItem> _temp = _dbContext.Mains.Where(m => m.Id == $"{_idOldMain}");
                foreach (MainItem item in _temp)
                {
                    item.Id = _mainEdit.Id;
                    item.LabelH1TextBox = _mainEdit.LabelH1TextBox;
                    item.LabelH3TextBox = _mainEdit.LabelH3TextBox;
                    item.LabelDescriptionTextBox = _mainEdit.LabelDescriptionTextBox;
                    item.UserNameTextBox = _mainEdit.UserNameTextBox;
                    item.EmailTextBox = _mainEdit.EmailTextBox;
                    item.ButtonChatTextBox = _mainEdit.ButtonChatTextBox;
                    item.Data = _mainEdit.Data;
                    item.DataLogo = _mainEdit.DataLogo;

                }
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<MainItem> _temp = _dbContext.Mains.Where(p => p.Id == $"{_id}");
                foreach (MainItem item in _temp)
                {
                    _dbContext.Mains.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
