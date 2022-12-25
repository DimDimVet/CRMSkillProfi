using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.Interfaces
{
    interface IUserRepozitory
    {
        Task<ObservableCollection<User>> GetUserList();
        Task<IUser> AddUser(IUser _user);
        Task<string> Delete(IUser _user);
        Task<string> EditUser(IUser _user);

    }
}
