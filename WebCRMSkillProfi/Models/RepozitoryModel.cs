using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebCRMSkillProfi.Interfaces;

namespace WebCRMSkillProfi.Models
{
    public class RepozitoryModel<T> : IRepozitoryModel<T>
    {
        private string _uriApi = Option.APIPATH;
        private HttpContent _content;
        private HttpResponseMessage _respon;
        private HttpClient _clientHttp;
        private ObservableCollection<T> _dbData;
        private IPathOption _pathOption;
        public RepozitoryModel(IPathOption _path)
        {
            _dbData = new ObservableCollection<T>();
            _pathOption = _path;
        }

        public async Task<ObservableCollection<T>> GetListData(IUser _user)
        {
            TokenAccount.АuthenticatorUser(_user.UserName, _user.Email);
            using (_clientHttp = TokenAccount.CreateTokenClient())
            {
                _respon = null;
                _respon = await _clientHttp.GetAsync(_uriApi + _pathOption.PathControll + _pathOption.Get);
                _respon.EnsureSuccessStatusCode();

                if (_respon.IsSuccessStatusCode)
                {
                    string _json = await _respon.Content.ReadAsStringAsync();
                    _dbData = JsonConvert.DeserializeObject<ObservableCollection<T>>(_json);
                    return _dbData;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<string> AddData(T _modelData, IUser _user)
        {
            TokenAccount.АuthenticatorUser(_user.UserName, _user.Email);
            using (_clientHttp = TokenAccount.CreateTokenClient())
            {
                string _json = JsonConvert.SerializeObject(_modelData, Formatting.Indented);
                _content = new StringContent(_json, Encoding.UTF8, "application/json");
                _respon = await _clientHttp.PostAsync(_uriApi + _pathOption.PathControll + _pathOption.Post, _content);
            }
            return _respon.Content.ReadAsStringAsync().Result;
        }
        public async Task<string> EditData(T _modelData, IUser _user)
        {
            TokenAccount.АuthenticatorUser(_user.UserName, _user.Email);
            using (_clientHttp = TokenAccount.CreateTokenClient())
            {
                string _json = JsonConvert.SerializeObject(_modelData, Formatting.Indented);
                _content = new StringContent(_json, Encoding.UTF8, "application/json");
                _respon = await _clientHttp.PutAsync(_uriApi + _pathOption.PathControll + _pathOption.Put, _content);
            }
            return _respon.Content.ReadAsStringAsync().Result;
        }
        public async Task<string> DeleteData(string _id, IUser _user)
        {
            TokenAccount.АuthenticatorUser(_user.UserName, _user.Email);
            using (_clientHttp = TokenAccount.CreateTokenClient())
            {
                _respon = await _clientHttp.DeleteAsync(_uriApi + _pathOption.PathControll + _pathOption.Delete + $"/{_id}");
            }
            return _respon.Content.ReadAsStringAsync().Result;
        }
    }
}
