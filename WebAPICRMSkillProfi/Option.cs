using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi
{
    public class Option
    {
        public static string DBPATH;
        // Event
        public static string ApiWebEventURL;
        public static void InitLoadTxt()
        {
            string _lineTxt;
            try
            {
                using (StreamReader _txtData = new StreamReader(@"wwwroot\config.txt"))
                {
                    while ((_lineTxt = _txtData.ReadLine()) != null)
                    {
                        string[] _resultTxt = _lineTxt.Split(new char[] { '-' });
                        for (int i = 0; i < _resultTxt.Length; i++)
                        {
                            switch (_resultTxt[i].Replace('*', ' ').Trim())
                            {
                                case "DBPATH":
                                    DBPATH = _resultTxt[i + 1];
                                    break;
                                case "ApiWebEventURL":
                                    ApiWebEventURL = _resultTxt[i + 1];
                                    break;

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                DBPATH = "Server=(localdb)\\mssqllocaldb;Database=testDom1;Trusted_Connection=True;MultipleActiveResultSets=true";
                ApiWebEventURL = "https://localhost:44338/api/event";
            }

        }


        //Default user
        public const string DefUser = "admin";
        public static List<User> Users;
        public static void AdminUserList(IEnumerable<User> _users)
        {
            Users = new List<User>(_users);
        }

        //Токен
        public const string ISSUER = "CRMAuthServer"; // издатель токена
        public const string AUDIENCE = "CRMAuthClient"; // потребитель токена
        public const string KEY = "CRM_secretkey!987";   // ключ для шифрации
        public const int LIFETIME = 5; // время жизни токена - 5 минута

        //генератор токена
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        
        //DefaultImg
        public const string ImagePath = @"wwwroot\DefaultImg\";//для записи в директорию
        public const string DefaultImgGround = "DefaultImgGround.png";
        public const string DefaultImgItem = "DefaultImgItem.png";
        public const string DefaultImgLogo = "DefaultImgLogo.png";
        public const string DefaultIconTelegram = "TelegramIcon.png";
    }
}
