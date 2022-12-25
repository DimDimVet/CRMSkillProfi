using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class ValuesUserRepozitory : IValuesModelRepozitory<User>
    {
        private DbSqlContext _dbContext;

        public ValuesUserRepozitory(DbSqlContext context)
        {
            this._dbContext = context;
        }

        #region User
        public async Task<IEnumerable<User>> GetListAsync()
        {
            await _dbContext.SaveChangesAsync();
            return _dbContext.Users;
        }
        public async Task AddAsync(User _user)
        {
            using (_dbContext = new DbSqlContext())
            {
                await _dbContext.Users.AddAsync(_user);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task EditAsync(string _idOldUser, User _userEdit)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<User> _temp = _dbContext.Users.Where(u => u.Id == $"{_idOldUser}");
                foreach (User item in _temp)
                {
                    item.Id = _userEdit.Id;
                    item.UserMiddleName = _userEdit.UserMiddleName;
                    item.UserName = _userEdit.UserName;
                    item.UserSurName = _userEdit.UserSurName;
                    item.Email = _userEdit.Email;
                    item.PasswordHash = _userEdit.PasswordHash;
                    item.PhoneNumber = _userEdit.PhoneNumber;
                    item.Address = _userEdit.Address;
                    item.Role = _userEdit.Role;
                    item.Desription = _userEdit.Desription;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(string _id)
        {
            using (_dbContext = new DbSqlContext())
            {
                IQueryable<User> _temp = _dbContext.Users.Where(p => p.Id == $"{_id}");
                foreach (User item in _temp)
                {
                    _dbContext.Users.Remove(item);
                }
                await _dbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
