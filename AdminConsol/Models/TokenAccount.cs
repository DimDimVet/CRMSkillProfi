using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace AdminConsol.Models
{
    class TokenAccount
    {
        private static string _uriApi = Option.APIPATH;
        public static string Token;
        //Обработчик
        public static void Аuthenticator()
        {
            string userName = Option.UserName;
            string email = Option.Email;
            Dictionary<string, string> tokenDictionary = GetTokenDictionary(userName, email);
            Token = tokenDictionary["access_token"];
        }
        // создаем http-клиента с токеном при каждом запросе
        public static HttpClient CreateTokenClient()
        {
            HttpClient _client = new HttpClient();
            if (!string.IsNullOrWhiteSpace(Token))
            {
                _client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token);
            }
            return _client;
        }

        //// получение токена
        private static Dictionary<string, string> GetTokenDictionary(string userName, string email)
        {
            List<KeyValuePair<string, string>> pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "Email" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "email", email )
                };
            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response;
                try
                {
                    response = client.PostAsync(_uriApi + "/token", content).Result;//проверку на ошибку
                }
                catch (Exception)
                {
                    throw;
                }

                string result = response.Content.ReadAsStringAsync().Result;
                // Десериализация полученного JSON-объекта
                Dictionary<string, string> tokenDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
                return tokenDictionary;
            }
        }
    }
}
