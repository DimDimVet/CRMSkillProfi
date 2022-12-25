using AdminConsol.Interfaces;
using System.IO;

namespace AdminConsol
{
    public class Option
    {
        //путь к API
        public static string APIPATH;
        //Токен
        public static string UserName;
        public static string Email;

        //Image
        public const string BackgroundIndexImage = "BackgroundIndexImage.png";//фон картинка main закладки
        public const string IdButtonNewImageMain = "1";//фон картинка main закладки, индекс в массиве
        public const string IdTextResursMain = "0";//фон картинка main закладки, индекс в массиве

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
                                case "UserName":
                                    UserName = _resultTxt[i + 1];
                                    break;
                                case "Email":
                                    Email = _resultTxt[i + 1];
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
                //Токен
                UserName = "admin";
                Email = "admin@admin.com";

            }

        }

        //pathControll

        public static PathOption PathMain = new PathOption
        {
            PathControll = "/api/ValuesMainItem/",
            Get = "GetListMain",
            Post = "PostNewMain",
            Put = "PutEditMain",
            Delete = "DeleteMain"
        };
        public static PathOption PathMessange = new PathOption
        {
            PathControll = "/api/ValuesMessange/",
            Get = "GetListMessange",
            Post = "PostNewMessange",
            Put = "PutEditMessange",
            Delete = "DeleteMess"
        };
        public static PathOption PathProject = new PathOption
        {
            PathControll = "/api/ValuesProjectItem/",
            Get = "GetListProject",
            Post = "PostNewProject",
            Put = "PutEditProject",
            Delete = "DeleteProject"
        };
        public static PathOption PathService = new PathOption
        {
            PathControll = "/api/ValuesServiceItem/",
            Get = "GetListService",
            Post = "PostNewService",
            Put = "PutEditService",
            Delete = "DeleteService"
        };
        public static PathOption PathUser = new PathOption
        {
            PathControll = "/api/ValuesUser/",
            Get = "GetListUser",
            Post = "PostNewUser",
            Put = "PutEditUser",
            Delete = "DeleteUser"
        };
        public static PathOption PathLink = new PathOption
        {
            PathControll = "/api/ValuesLinkItem/",
            Get = "GetListLink",
            Post = "PostNewLink",
            Put = "PutEditLink",
            Delete = "DeleteLink"
        };
        public static PathOption PathContact = new PathOption
        {
            PathControll = "/api/ValuesContactItem/",
            Get = "GetListContact",
            Post = "PostNewContact",
            Put = "PutEditContact",
            Delete = "DeleteContact"
        };
        public static PathOption PathBlog = new PathOption
        {
            PathControll = "/api/ValuesBlogItem/",
            Get = "GetListBlog",
            Post = "PostNewBlog",
            Put = "PutEditBlog",
            Delete = "DeleteBlog"
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
