using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebCRMSkillProfi.Interfaces;

namespace WebCRMSkillProfi.Models
{
    public class LogicModel<M>
    {
        private ObservableCollection<M> _collectionFromRep;
        private IRepozitoryModel<M> _currRepository;
        public LogicModel(IPathOption _pathControll)
        {
            _collectionFromRep = new ObservableCollection<M>();
            _currRepository = new RepozitoryModel<M>(_pathControll);
        }
        public ObservableCollection<M> Get(IUser _user)
        {
            _collectionFromRep = _currRepository.GetListData(_user).Result;
            return _collectionFromRep;
        }
        public async Task<ObservableCollection<M>> GetAsync(IUser _user)
        {
            _collectionFromRep = await _currRepository.GetListData(_user);
            return _collectionFromRep;
        }
        public void Add(M _currentItem, IUser _user)
        {
            _currRepository.AddData(_currentItem, _user);
        }
        public async Task AddAsync(M _currentItem, IUser _user)
        {
           await _currRepository.AddData(_currentItem, _user);
        }
        public void Edit(M _currentItem, IUser _user)
        {
            _currRepository.EditData(_currentItem, _user);
        }
        public async Task EditAsync(M _currentItem, IUser _user)
        {
            await _currRepository.EditData(_currentItem, _user);
        }
        public void Delete(string _id, IUser _user)
        {
            _currRepository.DeleteData(_id, _user);
        }
        public async Task DeleteAsync(string _id, IUser _user)
        {
           await _currRepository.DeleteData(_id, _user);
        }
    }
}
