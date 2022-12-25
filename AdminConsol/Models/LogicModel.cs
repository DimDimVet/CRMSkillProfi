using AdminConsol.Interfaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AdminConsol.Models
{
    class LogicModel<M>
    {
        private ObservableCollection<M> _collectionFromRep;
        private IRepozitoryModel<M> _currRepository;

        public LogicModel(IPathOption _pathControll)
        {
            _collectionFromRep = new ObservableCollection<M>();
            _currRepository = new RepozitoryModel<M>(_pathControll);
        }
        public ObservableCollection<M> Get()
        {
            _collectionFromRep = _currRepository.GetListData().Result;
            return _collectionFromRep;
        }
        public async Task<ObservableCollection<M>> GetAsync()
        {
            _collectionFromRep = await _currRepository.GetListData();
            return _collectionFromRep;
        }
        public void Add(M _currentItem)
        {
            _currRepository.AddData(_currentItem);
        }
        public void Edit(M _currentItem)
        {
            _currRepository.EditData(_currentItem);
        }
        public void Delete(string _id)
        {
            _currRepository.DeleteData(_id);
        }
    }
}
