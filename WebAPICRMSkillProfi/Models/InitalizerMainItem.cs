using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICRMSkillProfi.Models
{
    public class InitalizerMainItem
    {
        private static DbSqlContext _dbContext;
        public static async Task InitializerMainItemAsync()
        {
            _dbContext = new DbSqlContext();
            if (_dbContext.Mains.FirstOrDefault(t => t.Id == "0") == null)
            {
                await _dbContext.Mains.AddAsync(new MainItem
                {
                    Id = "0",
                    LabelH1TextBox = "IT-Конгсалтинг",
                    LabelH3TextBox = "БЕЗ РЕГИСТРАЦИИ И СМС",
                    LabelDescriptionTextBox = "Оставить заявку или задать вопрос",
                    UserNameTextBox = "Имя",
                    EmailTextBox = "Email",
                    ButtonChatTextBox = "Открыть чат",
                    Data= DefaultImg(Option.DefaultImgGround),
                    DataLogo=  DefaultImg(Option.DefaultImgLogo)
                });
                await _dbContext.Projects.AddAsync(new ProjectItem
                {
                    Id = "0",
                    Title="TitleDefaulTest",
                    Desription= "DesriptionDefaulTest",
                    Data =  DefaultImg(Option.DefaultImgItem)
                });
                await _dbContext.Service.AddAsync(new ServiceItem
                {
                    Id = "0",
                    TitleService = "TitleDefaulTest",
                    DesriptionService="DesriptionDefaulTest"
                });
                await _dbContext.Blogs.AddAsync(new BlogItem
                {
                    Id = "0",
                    TitleBlog = "TitleDefaulTest",
                    DesriptionBlog = "DesriptionDefaulTest",
                    DateBlog="0.0.0.0",
                    Data =  DefaultImg(Option.DefaultImgItem)
                });
                await _dbContext.Links.AddAsync(new LinkItem
                {
                    Id = "0",
                    Url = "https://t.me/CRMSkillProfi_bot",
                    Data =  DefaultImg(Option.DefaultIconTelegram)
                });
                await _dbContext.Contacts.AddAsync(new ContactItem
                {
                    Id = "0",
                    TextContactA = "SityDefaulTest",
                    TextContactB= "StreetDefaulTest",
                    TextContactC = "PhoneDefaulTest",
                    Data =  DefaultImg(Option.DefaultImgItem)
                });
                await _dbContext.SaveChangesAsync();
            }
        }


        private static byte[] DefaultImg(string _nameImg)
        {
            byte[] _dataImg;
            using (FileStream _fs = new FileStream(Option.ImagePath + _nameImg, FileMode.Open))
            {
                _dataImg = new byte[_fs.Length];
                _fs.Read(_dataImg, 0, _dataImg.Length);
            }
            return _dataImg;
        }
    }

}
