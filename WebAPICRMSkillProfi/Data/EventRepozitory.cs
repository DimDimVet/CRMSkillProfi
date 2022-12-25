using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi.Data
{
    public class EventRepozitory
    {
        private HttpClient _clientHttp;
        private HttpResponseMessage _respon;
        private HttpContent _content;
        public EventRepozitory()
        {
            _clientHttp = new HttpClient();
            _respon = new HttpResponseMessage();
        }
        public async Task EventMessange(Messange _eventMessange)
        {
            string _json = JsonConvert.SerializeObject(_eventMessange, Formatting.Indented);
            _content = new StringContent(_json, Encoding.UTF8, "application/json");
            _respon = await _clientHttp.PostAsync(Option.ApiWebEventURL, _content);
        }
    }
}
