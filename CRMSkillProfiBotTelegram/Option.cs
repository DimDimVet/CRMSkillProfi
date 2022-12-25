using CRMSkillProfiBotTelegram.Interfaces;
using System.IO;

namespace CRMSkillProfiBotTelegram
{
    public class Option
    {
        //путь к API
        public static string APIPATH;
        //Error Messange bot
        public static string ErrorText;
        //Return Messange bot
        public static string CurrentUserReturn;
        public static string CurrentUserHello;
        public static string ErrorServer;

        public static void InitLoadTxt()
        {
            string _lineTxt;
            try
            {
                using (StreamReader _txtData = new StreamReader(@"wwwroot\config.txt"))
                {
                    while ((_lineTxt = _txtData.ReadLine()) != null)
                    {
                        string[] _resultTxt = _lineTxt.Split(new char[] { '=' });
                        for (int i = 0; i < _resultTxt.Length; i++)
                        {
                            switch (_resultTxt[i].Replace('*', ' ').Trim())
                            {
                                case "APIPATH":
                                    APIPATH = _resultTxt[i + 1];
                                    break;
                                case "ErrorText":
                                    ErrorText = _resultTxt[i + 1];
                                    break;
                                case "CurrentUserReturn":
                                    CurrentUserReturn = _resultTxt[i + 1];
                                    break;
                                case "CurrentUserHello":
                                    CurrentUserHello = _resultTxt[i + 1];
                                    break;
                                case "ErrorServer":
                                    ErrorServer = _resultTxt[i + 1];
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
                //путь к API
                APIPATH = "https://localhost:44316";
                //Error Messange bot
                ErrorText = "Все замечательно, НО лучьше мне написать :)";
                //Return Messange bot
                CurrentUserReturn = "Ваше сообщение упаковано и отправлено оператору";
                CurrentUserHello = "Привет! Я упакую ваше сообщение и отправлю оператору";
                ErrorServer = "Что то пошло не так, нет ответа от сервера";
            }

        }


        //Токен
        public const string UserName = "admin";
        public const string Email = "admin@admin.com";

        //token bot
        public const string BotToken = "5817166490:AAHM-SI_5anCSgZzu3Hl6r86S849yNS7O-0";

        //pathControll

        public static PathOption PathMessange = new PathOption
        {
            PathControll = "/api/ValuesMessange/",
            Get = "GetListMessange",
            Post = "PostNewMessange",
            Put = "PutEditMessange",
            Delete = "DeleteMess"
        };
        public static PathOption PathUser = new PathOption
        {
            PathControll = "/api/ValuesUser/",
            Get = "GetListUser",
            Post = "PostNewUser",
            Put = "PutEditUser",
            Delete = "DeleteUser"
        };

    }
    public class PathOption : IPathOption
    {
        public string PathControll { get; set; }
        public string Get { get; set; }
        public string Post { get; set; }
        public string Put { get; set; }
        public string Delete { get; set; }
    }
}
