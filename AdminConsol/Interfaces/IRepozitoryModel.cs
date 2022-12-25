using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AdminConsol.Interfaces
{
    interface IRepozitoryModel<T>
    {
        Task<string> AddData(T _modelData);
        Task<string> DeleteData(string _id);
        Task<string> EditData(T _modelData);
        Task<ObservableCollection<T>> GetListData();
    }
}