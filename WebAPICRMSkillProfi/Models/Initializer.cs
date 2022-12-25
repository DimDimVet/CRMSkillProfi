using System.Linq;
using System.Threading.Tasks;

namespace WebAPICRMSkillProfi.Models
{
    public class Initializer
    {
        private static DbSqlContext _dbContext;
        public static async Task InitializerAsync()
        {
            _dbContext = new DbSqlContext();

            string _adminName = "admin";
            string _adminEmail = "admin@admin.com";
            string _userName = "test";
            string _userEmail = "test@test.com";

            if (_dbContext.Roles.FirstOrDefault(r => r.Name == "admin") == null)
            {
                await _dbContext.Roles.AddAsync(new Role { Name = "admin" });
                await _dbContext.SaveChangesAsync();
            }

            if (_dbContext.Roles.FirstOrDefault(r => r.Name == "user") == null)
            {
                await _dbContext.Roles.AddAsync(new Role { Name = "user" });
                await _dbContext.SaveChangesAsync();
            }

            if (_dbContext.Users.FirstOrDefault(u => u.UserName == _adminName) == null)
            {
                User _admin = new User
                {
                    Id = "0",
                    Email = _adminEmail,
                    UserName = _adminName,
                    UserSurName = "null",
                    UserMiddleName = "null",
                    Desription = "null",
                    PhoneNumber = "null",
                    Address = "null",
                    PasswordHash = "null",
                    Role = "admin"
                };
                await _dbContext.Users.AddAsync(_admin);
                User _user = new User
                {
                    Id = "1",
                    Email = _userEmail,
                    UserName = _userName,
                    UserSurName = "null",
                    UserMiddleName = "null",
                    Desription = "null",
                    PhoneNumber = "null",
                    Address = "null",
                    PasswordHash = "null",
                    Role = "user"
                };
                await _dbContext.Users.AddAsync(_user);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
