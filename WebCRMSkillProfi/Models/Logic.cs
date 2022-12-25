using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WebCRMSkillProfi.Interfaces;
using WebCRMSkillProfi.ViewModels;

namespace WebCRMSkillProfi.Models
{
    public class Logic
    {
        private static IUser _defUser = new User { UserName = Option.UserName, Email = Option.Email};
        //
        private static LogicModel<MainItem> _mainLogic = new LogicModel<MainItem>(Option.PathMain);
        private static LogicModel<User> _userLogic = new LogicModel<User>(Option.PathUser);
        private static LogicModel<Messange> _messangeLogic = new LogicModel<Messange>(Option.PathMessange);
        private static LogicModel<ProjectItem> _projectLogic = new LogicModel<ProjectItem>(Option.PathProject);
        private static LogicModel<BlogItem> _blogLogic = new LogicModel<BlogItem>(Option.PathBlog);
        private static LogicModel<ContactItem> _contactLogic = new LogicModel<ContactItem>(Option.PathContact);
        private static LogicModel<ServiceItem> _serviceLogic = new LogicModel<ServiceItem>(Option.PathService);
        private static LogicModel<LinkItem> _linkLogic = new LogicModel<LinkItem>(Option.PathLink);

        private static ObservableCollection<MainItem> _mainGet;
        private static ObservableCollection<User> _userGet;
        private static ObservableCollection<Messange> _messangeGet;
        private static ObservableCollection<ProjectItem> _projectGet;
        private static ObservableCollection<BlogItem> _blogGet;
        private static ObservableCollection<ContactItem> _contactGet;
        private static ObservableCollection<ServiceItem> _serviceGet;
        private static ObservableCollection<LinkItem> _linkGet;
        //

        public static bool ControlApi()
        {
            try
            {
                _mainGet = _mainLogic.Get(_defUser);
                _userGet = _userLogic.Get(_defUser);
                _messangeGet = _messangeLogic.Get(_defUser);
                _projectGet = _projectLogic.Get(_defUser);
                _blogGet = _blogLogic.Get(_defUser);
                _contactGet = _contactLogic.Get(_defUser);
                _serviceGet = _serviceLogic.Get(_defUser);
                _linkGet = _linkLogic.Get(_defUser);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        #region Main
        private static void LoadHomeImage()
        {
            try
            {
                for (int i = 0; i < _mainGet.Count; i++)
                {
                    if (_mainGet[i].Data != null)
                    {
                        using (FileStream fs = new FileStream(Option.ImagePath + Option.BackgroundImage, FileMode.Create))
                        {
                            fs.Write(_mainGet[i].Data, 0, _mainGet[i].Data.Length);
                        }
                    }
                    if (_mainGet[i].DataLogo != null)
                    {
                        using (FileStream fs = new FileStream(Option.ImagePath + Option.LogoImage, FileMode.Create))
                        {
                            fs.Write(_mainGet[i].DataLogo, 0, _mainGet[i].DataLogo.Length);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public static HomeViewModel LoadHomeResurs()
        {
            _mainGet = _mainLogic.Get(_defUser);
            HomeViewModel _model = null;
            LoadHomeImage();
            for (int i = 0; i < _mainGet.Count; i++)
            {
                if (i == 0)
                {
                    _model = new HomeViewModel
                    {
                        _LabelH1 = _mainGet[i].LabelH1TextBox,
                        _LabelH3 = _mainGet[i].LabelH3TextBox,
                        _LabelDescription = _mainGet[i].LabelDescriptionTextBox,
                        _UserNameLabel = _mainGet[i].UserNameTextBox,
                        _EmailLabel = _mainGet[i].EmailTextBox,
                        _ButtonNameChat = _mainGet[i].ButtonChatTextBox,
                        _imagePath = Option.SmallImagePath + Option.BackgroundImage,
                        _imageLogo= Option.SmallImagePath + Option.LogoImage
                    };
                }
            }
            return _model;
        }
        #endregion

        #region User
        public static async Task<IUser> ControlUser(IUser _testUser)
        {
            try
            {
                _userGet = _userLogic.Get(_defUser);
                for (int i = 0; i < _userGet.Count; i++)
                {
                    if ((_userGet[i].UserName == _testUser.UserName) && (_userGet[i].Email == _testUser.Email))
                    {
                        return _userGet[i];
                    }
                }
                await AddUser(_testUser);
                return _testUser;
            }
            catch (Exception)
            {

            }
            return null;
        }
        private static async Task AddUser(IUser _user)
        {

            int _lastId = 0;
            for (int i = 0; i < _userGet.Count; i++)
            {
                int _tempId = int.Parse(_userGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            _user.Id = $"{_lastId}";
            _user.PasswordHash = "0000";
            _user.Role = "user";
            await _userLogic.AddAsync((User)_user, _defUser);
        }
        #endregion

        #region Chat
        public static void SaveMessange(ChatViewModel _model)
        {
            IUser _conkretUser = ControlUser(_model._User).Result;
            DateTime _now = DateTime.Now;
            string _complexText = $"{_now}\n {_conkretUser.UserName} -> {_model._TextNewMessange}\n\n";
            Messange _newMessange = new Messange
            {
                Id = _model._Id,
                TextMessange = _complexText,
                UserRecipientMess = Option.UserName,
                EmailSender = _model._User.Email,
                TimeRequest = $"{_now}"
            };
            if (_newMessange.Id == null)
            {
                AddMessange(_newMessange, _conkretUser);
            }
            else
            {
                EditMessange(_newMessange, _conkretUser);
            }
        }

        public static ChatViewModel PersonChat(IUser _user)
        {
            _messangeGet = _messangeLogic.Get(_defUser);
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                if ((_messangeGet[i].EmailSender == _user.Email) ^ (_messangeGet[i].UserRecipientMess == _user.Email))
                {
                    return new ChatViewModel {_Id=_messangeGet[i].Id, _TextMessange = _messangeGet[i], _User = (User)_user };
                }
            }
            DateTime _now = DateTime.Now;
            Messange _newMessange = new Messange
            {
                Id = null,
                TextMessange = "Привет!",
                UserRecipientMess = Option.UserName,
                EmailSender = _user.Email,
                TimeRequest = $"{_now}"
            };
            return new ChatViewModel { _TextMessange = _newMessange, _User = (User)_user };
        }
        public static void AddMessange(Messange _messange, IUser _user)
        {
            _messangeGet = _messangeLogic.Get(_defUser);
            //id
            int _lastId = 0;
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                int _tempId = int.Parse(_messangeGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            _messange.Id = $"{_lastId}";
            //
            _messangeLogic.Add(_messange, _user);
            _messangeGet.Add(_messange);
        }
        public static void EditMessange(Messange _messange, IUser _user)
        {
            _messangeGet = _messangeLogic.Get(_defUser);
            //UI
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                if (_messangeGet[i].Id == _messange.Id)
                {
                    _messange.TextMessange += _messangeGet[i].TextMessange;
                    //
                    _messangeGet.Insert(i, _messange);
                    _messangeGet.RemoveAt(i + 1);
                }
            }
            _messangeLogic.Edit(_messange, _user);
        }
        #endregion

        #region Project
        public static ProjectViewModel LoadProjectResurs()
        {
            _projectGet = _projectLogic.Get(_defUser);
            ProjectViewModel _model = null;
            _model = new ProjectViewModel
            {
                _ProjectList = LoadProjectImage(),
                _imagePath = Option.BackgroundImage,
            };
            return _model;
        }
        private static ObservableCollection<ProjectItem> LoadProjectImage()
        {
            try
            {
                for (int i = 0; i < _projectGet.Count; i++)
                {
                    if (_projectGet[i].Data != null)
                    {
                        using (FileStream fs = new FileStream(Option.ImagePath + ($"{i}" + Option.ProjectImage), FileMode.Create))
                        {
                            fs.Write(_projectGet[i].Data, 0, _projectGet[i].Data.Length);
                            _projectGet[i].ImageProjectPath = ($"{i}" + Option.ProjectImage);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return _projectGet;
        }
        public static ProjectViewModel OpenProjectItem(string _id)
        {
            //_projectGet = _projectLogic.Get(_defUser);
            ProjectViewModel _model = null;
            for (int i = 0; i < _projectGet.Count; i++)
            {
                if (_projectGet[i].Id == _id)
                {
                    _model = new ProjectViewModel
                    {
                        _Item= _projectGet[i],
                        _imagePath = Option.BackgroundImage
                    };
                }
            }
            return _model;
        }
        #endregion

        #region Blog
        public static BlogViewModel LoadBlogResurs()
        {
            _blogGet = _blogLogic.Get(_defUser);
            BlogViewModel _model = null;
            _model = new BlogViewModel
            {
                _BlogList = LoadBlogImage(),
                _imagePath = Option.BackgroundImage,

            };
            return _model;
        }
        private static ObservableCollection<BlogItem> LoadBlogImage()
        {
            try
            {
                for (int i = 0; i < _blogGet.Count; i++)
                {
                    if (_blogGet[i].Data != null)
                    {
                        using (FileStream fs = new FileStream(Option.ImagePath + ($"{i}" + Option.BlogImage), FileMode.Create))
                        {
                            fs.Write(_blogGet[i].Data, 0, _blogGet[i].Data.Length);
                            _blogGet[i].ImageBlogPath = ($"{i}" + Option.BlogImage);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return _blogGet;
        }
        public static BlogViewModel OpenBlogtem(string _id)
        {
            BlogViewModel _model = null;
            for (int i = 0; i < _blogGet.Count; i++)
            {
                if (_blogGet[i].Id == _id)
                {
                    _model = new BlogViewModel
                    {
                        _Item = _blogGet[i],
                        _imagePath = Option.BackgroundImage
                    };
                }
            }
            return _model;
        }
        #endregion

        #region Contact
        public static ContactViewModel LoadContactResurs()
        {
            _contactGet = _contactLogic.Get(_defUser);
            _linkGet = _linkLogic.Get(_defUser);
            ContactViewModel _model = null;
            try
            {
                for (int i = 0; i < _contactGet.Count; i++)
                {
                    if (_contactGet[i].Data != null)
                    {
                        using (FileStream fs = new FileStream(Option.ImagePath + ($"{i}" + Option.ContactImage), FileMode.Create))
                        {
                            fs.Write(_contactGet[i].Data, 0, _contactGet[i].Data.Length);
                        }
                        _model = new ContactViewModel
                        {
                            _TextContactA = _contactGet[i].TextContactA,
                            _TextContactB = _contactGet[i].TextContactB,
                            _TextContactC = _contactGet[i].TextContactC,
                            _imagePath = Option.BackgroundImage,
                            ImageContactPath = ($"{i}" + Option.ContactImage),
                            _Link= LoadLinkResurs()
                        };
                    }
                }
            }
            catch (Exception)
            {

            }
            return _model;
        }
        #endregion

        #region Link
        public static ObservableCollection<LinkItem> LoadLinkResurs()
        {
            _linkGet = _linkLogic.Get(_defUser);
            ObservableCollection<LinkItem> _collectionLink = new ObservableCollection<LinkItem>();
            for (int i = 0; i < _linkGet.Count; i++)
            {
                if (_linkGet[i].Data != null)
                {
                    using (FileStream fs = new FileStream(Option.ImagePath + ($"{i}" + Option.LinkImage), FileMode.Create))
                    {
                        fs.Write(_linkGet[i].Data, 0, _linkGet[i].Data.Length);
                    }
                    LinkItem _item = new LinkItem
                    {
                        ImageLinkPath= ($"{i}" + Option.LinkImage),
                        Url= _linkGet[i].Url
                    };
                    _collectionLink.Add(_item);
                }
            }
            return _collectionLink;
        }
        #endregion

        #region Service
        public static ServiceViewModel LoadServiceResurs()
        {
            _serviceGet = _serviceLogic.Get(_defUser);
            ServiceViewModel _model = null;
            try
            {
                _model = new ServiceViewModel
                {
                    _ServiceList = _serviceGet,
                    _imagePath = Option.BackgroundImage,

                };
            }
            catch (Exception)
            {

            }
            return _model;
            #endregion
        }
    }
}
