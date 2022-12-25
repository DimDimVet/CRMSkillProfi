using System.IO;
using WebCRMSkillProfi.Interfaces;

namespace WebCRMSkillProfi
{
    public class Option
    {
        //путь к API
        public static string APIPATH;
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

                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                APIPATH = "https://localhost:44316";
            }

        }

        //Токен
        public const string UserName = "admin";
        public const string Email = "admin@admin.com";
        //Image
        public const string BackgroundImage = "BackgroundHomeImage.png";//для home
        public const string LogoImage = "LogoImage.png";//для home
        public const string ProjectImage = "ProjectImage.png";//для project
        public const string BlogImage = "BlogImage.png";//для blog
        public const string ContactImage = "ContactImage.png";//для contact
        public const string LinkImage = "LinkImage.png";//для link

        public const string ImagePath = @"wwwroot\images\";//для записи в директорию
        public const string SmallImagePath = @"images\";//для home

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

