using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WebCRMSkillProfi.Interfaces
{
    public interface IRepozitoryModel<T>
    {
        Task<string> AddData(T _modelData, IUser _user);
        Task<string> DeleteData(string _id, IUser _user);
        Task<string> EditData(T _modelData, IUser _user);
        Task<ObservableCollection<T>> GetListData(IUser _user);
    }
}