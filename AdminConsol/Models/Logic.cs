using AdminConsol.View;
using AdminConsol.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using static AdminConsol.Models.User;

namespace AdminConsol.Models
{
    class Logic
    {
        private static byte[] ImageDataControlPhotoMain;
        private static byte[] ImageDataControlLogoImg;
        private static byte[] ImageDataControlImageProject;
        private static byte[] ImageDataControlPhotoBlog;
        private static byte[] ImageDataControlContactImg;
        private static byte[] ImageDataControlLinkImg;
        private static UserViewModel _userViewModel;
        private static ConsoleMessangeViewModel _messangeViewModel;
        public static bool StatusApi;

        #region supp
        private static LogicModel<User> _userLogic = new LogicModel<User>(Option.PathUser);
        private static LogicModel<Messange> _messangeLogic = new LogicModel<Messange>(Option.PathMessange);
        private static LogicModel<MainItem> _mainLogic = new LogicModel<MainItem>(Option.PathMain);
        private static LogicModel<ProjectItem> _projectLogic = new LogicModel<ProjectItem>(Option.PathProject);
        private static LogicModel<ServiceItem> _serviceLogic = new LogicModel<ServiceItem>(Option.PathService);
        private static LogicModel<BlogItem> _blogLogic = new LogicModel<BlogItem>(Option.PathBlog);
        private static LogicModel<ContactItem> _contactLogic = new LogicModel<ContactItem>(Option.PathContact);
        private static LogicModel<LinkItem> _linkLogic = new LogicModel<LinkItem>(Option.PathLink);

        private static ObservableCollection<User> _userGet;
        private static ObservableCollection<Messange> _messangeGet;
        private static ObservableCollection<MainItem> _mainGet;
        private static ObservableCollection<ProjectItem> _projectGet;
        private static ObservableCollection<ServiceItem> _serviceGet;
        private static ObservableCollection<BlogItem> _blogGet;
        private static ObservableCollection<ContactItem> _contactGet;
        private static ObservableCollection<LinkItem> _linkGet;

        private static ConsolViewModel _modelConsol = new ConsolViewModel();

        public static BitmapFrame ImageConvertor(byte[] _dataImage)
        {
            BitmapFrame _image = null;
            //
            if (_dataImage != null)
            {
                using (MemoryStream _ms = new MemoryStream(_dataImage))
                {
                    try
                    {
                        _image = BitmapFrame.Create(_ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                    }
                    catch (Exception)
                    {

                        return null;
                    }

                }
            }
            return _image;
        }
        public static byte[] NewImage()
        {
            OpenFileDialog _fd = new OpenFileDialog();
            _fd.Filter = "Image Files(*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All Files (*.*)|*.*";
            if (_fd.ShowDialog() != null && _fd.FileName != "")
            {
                Uri myUri = new Uri(_fd.FileName);
                try
                {
                    string _imagePath = _fd.FileName;
                    string _faleTitle = _imagePath.Substring(_imagePath.LastIndexOf('\\') + 1);
                    using (FileStream _fs = new FileStream(_imagePath, FileMode.Open))
                    {
                        byte[] _imageDataControl = new byte[_fs.Length];
                        _fs.Read(_imageDataControl, 0, _imageDataControl.Length);
                        return _imageDataControl;
                    }
                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Не возможно открыть файл", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            return null;
        }
        public static void SortData(string _stringSorted)
        {
            SortedCriterion _sorted = new SortedCriterion();
            switch (_stringSorted)
            {
                case "UserSurName":
                    _sorted = SortedCriterion.UserSurName;
                    break;
                case "UserName":
                    _sorted = SortedCriterion.UserName;
                    break;
                case "UserMiddleName":
                    _sorted = SortedCriterion.UserMiddleName;
                    break;
                case "Email":
                    _sorted = SortedCriterion.Email;
                    break;
                case "PhoneNumber":
                    _sorted = SortedCriterion.PhoneNumber;
                    break;
                case "Address":
                    _sorted = SortedCriterion.Address;
                    break;
                case "Role":
                    _sorted = SortedCriterion.Role;
                    break;

                default:
                    break;
            }

            IEnumerable<User> _collection = _userGet;
            List<User> _collectionList = new List<User>(_collection);

            _collectionList.Sort(User.SortedBy(_sorted));
            _userGet = new ObservableCollection<User>(_collectionList);
            _userViewModel.UserListView = _userGet;
        }
        #endregion

        #region Consol
        public static bool ControlApi()
        {
            try
            {
                _userGet = _userLogic.Get();
                _mainGet = _mainLogic.Get();
                _messangeGet = _messangeLogic.Get();
                _projectGet = _projectLogic.Get();
                _serviceGet = _serviceLogic.Get();
                _blogGet = _blogLogic.Get();
                _contactGet = _contactLogic.Get();
                _linkGet = _linkLogic.Get();
                return StatusApi=true;
            }
            catch (Exception)
            {
                MessageBoxResult _result =MessageBox.Show("Нет ответа сервера, закрыть консоль","API",MessageBoxButton.OK);
                
                return StatusApi = false;
            }
        }

        public static ConsolViewModel InitializeConsol()
        {
            

                for (int i = 0; i < _mainGet.Count; i++)
                {
                    _modelConsol.Id = _mainGet[i].Id;
                    _modelConsol.LabelH1TextBox = _mainGet[i].LabelH1TextBox;
                    _modelConsol.LabelH3TextBox = _mainGet[i].LabelH3TextBox;
                    _modelConsol.LabelDescriptionTextBox = _mainGet[i].LabelDescriptionTextBox;
                    _modelConsol.UserNameTextBox = _mainGet[i].UserNameTextBox;
                    _modelConsol.EmailTextBox = _mainGet[i].EmailTextBox;
                    _modelConsol.ButtonChatTextBox = _mainGet[i].ButtonChatTextBox;
                    _modelConsol.PhotoMain = LoadPhotoMain(_mainGet[i].Data);
                    _modelConsol.LogoImg = LoadLogoImg(_mainGet[i].DataLogo);
                    _modelConsol.ListMessange = _messangeGet;
                    _modelConsol.ProjectListView = ProjectListView(_projectGet);
                    _modelConsol.ServiceListView = _serviceGet;
                    _modelConsol.BlogtListView = BlogtListView(_blogGet);
                    _modelConsol.ImageContact = ImageContact(_contactGet);
                    _modelConsol.TextContactA = TextContactA(_contactGet);
                    _modelConsol.TextContactB = TextContactB(_contactGet);
                    _modelConsol.TextContactC = TextContactC(_contactGet);
                    _modelConsol.LinkListView = LinkListView(_linkGet);
                }

                return _modelConsol;
        }
        #endregion

        #region User
        public static void OpenViewUser()
        {
            _userViewModel = new UserViewModel();
            _userViewModel.UserListView = _userGet;
            ViewUser _viewUser = new ViewUser(_userViewModel);
            _viewUser.Show();
        }
        public static void OpenViewUserCard(User _item)
        {

            UserCardViewModel _model = new UserCardViewModel(); ;
            if (_item == null)
            {
                _model.Mode = true;
                _model.Id = null;
                _model.UserSurName = "Пусто";
                _model.UserName = "Пусто";
                _model.UserMiddleName = "Пусто";
                _model.Email = "Пусто";
                _model.PhoneNumber = "Пусто";
                _model.Address = "Пусто";
                _model.Role = "user";
                _model.Desription = "Пусто";

            }
            else
            {
                _model.Mode = false;
                _model.Id = _item.Id;
                _model.UserSurName = _item.UserSurName;
                _model.UserName = _item.UserName;
                _model.UserMiddleName = _item.UserMiddleName;
                _model.Email = _item.Email;
                _model.PhoneNumber = _item.PhoneNumber;
                _model.Address = _item.Address;
                _model.Role = _item.Role;
                _model.Desription = _item.Desription;
            }
            ViewUserCard _viewUserCard = new ViewUserCard(_model, false);
            _viewUserCard.SaveButton.Visibility = Visibility.Visible;
            _viewUserCard.FindButton.Visibility = Visibility.Hidden;
            _viewUserCard.Show();
        }

        public static void AddUser(UserCardViewModel _model)
        {
            //id
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
            User _item = new User
            {
                Id = $"{_lastId}",
                UserSurName = _model.UserSurName,
                UserName = _model.UserName,
                UserMiddleName = _model.UserMiddleName,
                Email = _model.Email,
                PhoneNumber = _model.PhoneNumber,
                Address = _model.Address,
                Role = _model.Role,
                Desription = _model.Desription
            };
            _userLogic.Add(_item);
            _userGet.Add(_item);
        }
        public static void EditUser(UserCardViewModel _model)
        {
            User _item = new User
            {
                Id = _model.Id,
                UserSurName = _model.UserSurName,
                UserName = _model.UserName,
                UserMiddleName = _model.UserMiddleName,
                Email = _model.Email,
                PhoneNumber = _model.PhoneNumber,
                Address = _model.Address,
                Role = _model.Role,
                Desription = _model.Desription
            };
            _userLogic.Edit(_item);
            //UI
            for (int i = 0; i < _userGet.Count; i++)
            {
                if (_userGet[i].Id == _item.Id)
                {
                    _userGet.Insert(i, _item);
                    _userGet.RemoveAt(i + 1);
                }
            }

        }
        public static void DeleteUser(User _item)
        {
            _userGet.Remove(_item);
            for (int i = 0; i < _userGet.Count; i++)
            {
                if (_userGet[i].Id == _item.Id)
                {
                    _userGet.RemoveAt(i);
                }
            }
            _userLogic.Delete(_item.Id);
        }

        public static void Find(UserCardViewModel _model)
        {
            User _user = new User
            {
                UserSurName = _model.UserSurName,
                UserName = _model.UserName,
                UserMiddleName = _model.UserMiddleName,
                Email = _model.Email,
                PhoneNumber = _model.PhoneNumber,
                Address = _model.Address,
                Role = _model.Role,
                Desription = _model.Desription
            };

            if (_user.UserSurName != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.UserSurName == _user.UserSurName) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
            if (_user.UserName != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.UserName == _user.UserName) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
            if (_user.UserMiddleName != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.UserMiddleName == _user.UserMiddleName) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
            if (_user.Email != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.Email == _user.Email) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
            if (_user.PhoneNumber != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.PhoneNumber == _user.PhoneNumber) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
            if (_user.Address != "")
            {
                try
                {
                    List<User> _rezultFind = new List<User> { _userGet.First(item => item.Address == _user.Address) };
                    EventList(_rezultFind);
                }
                catch (Exception)
                {
                    EventList(_userGet);
                }
            }
        }
        private static void EventList(IEnumerable<User> _rezultFind)
        {
            _userViewModel.UserListView = new ObservableCollection<User>(_rezultFind);
        }
        public static void FindWinUser()
        {
            UserCardViewModel _findItem = new UserCardViewModel
            {
                UserSurName = "",
                UserName = "",
                UserMiddleName = "",
                Email = "",
                PhoneNumber = "",
                Address = "",
                Role = "",
                Desription = ""
            };
            ViewUserCard _viewUserCard = new ViewUserCard(_findItem, true);

            _viewUserCard.SaveButton.Visibility = Visibility.Hidden;
            _viewUserCard.FindButton.Visibility = Visibility.Visible;
            _viewUserCard.RoleTextBox.IsEnabled = false;
            _viewUserCard.DesriptionTextBox.IsEnabled = false;
            _viewUserCard.Show();
        }
        public static void RefCollection()
        {
            _userViewModel.UserListView = new ObservableCollection<User>(_userGet);
        }
        #endregion

        #region Messange
        public static void OpenViewMessange(Messange _itemMess)
        {
            DateTime _now = DateTime.Now;
            if (_itemMess == null)
            {
                _messangeViewModel = new ConsoleMessangeViewModel
                {
                    Mode = true,
                    TimeRequest = $"{_now}",
                    TextMessange = "",
                    NewTextMessange = "Привет,",
                    EmailComboBox = _userGet,
                    EmailSender = $"{Option.UserName}"
                };
            }
            else
            {
                ObservableCollection<User> _currUser = new ObservableCollection<User>();

                if (_itemMess.UserRecipientMess== $"{Option.UserName}" || _itemMess.UserRecipientMess=="admin")
                {
                    _itemMess.UserRecipientMess = _itemMess.EmailSender;
                }
                for (int i = 0; i < _userGet.Count; i++)
                {
                    if (_userGet[i].Email == _itemMess.UserRecipientMess)
                    {
                        _currUser.Add(_userGet[i]);
                    }
                }
                _messangeViewModel = new ConsoleMessangeViewModel
                {
                    Mode = false,
                    Id = _itemMess.Id,
                    TimeRequest = $"{_now}",
                    TextMessange = _itemMess.TextMessange,
                    NewTextMessange = "Привет,",
                    EmailComboBox = _currUser,
                    UserRecipientMess = _itemMess.UserRecipientMess,
                    EmailSender = $"{Option.UserName}"
                };
            }

            ViewConsoleMessange _viewMessange = new ViewConsoleMessange(_messangeViewModel);
            _viewMessange.Show();
        }
        public async static void RefMessange()
        {
            
            ObservableCollection<Messange> _messangeGetTemp = new ObservableCollection<Messange>(await _messangeLogic.GetAsync());
            ObservableCollection<User> _userGetTemp = new ObservableCollection<User>(await _userLogic.GetAsync());
            //UI
            int length = 1;
            for (int i = 0; i < length; i++)
            {
                if (_messangeGetTemp != null)
                {
                    _messangeGet.Clear();
                    _userGet.Clear();
                    for (int y = 0; y < _messangeGetTemp.Count; y++)
                    {
                        _messangeGet.Add(_messangeGetTemp[y]);
                    }
                    for (int y = 0; y < _userGetTemp.Count; y++)
                    {
                        _userGet.Add(_userGetTemp[y]);
                    }
                }
                else
                {
                    length++;
                }
            }
            
        }
        public static void DeleteChat(Messange _item)
        {
            for (int i = 0; i < _messangeGet.Count; i++)
            {
                if (_messangeGet[i].Id == _item.Id)
                {
                    _messangeGet.RemoveAt(i);
                }
            }
            _messangeLogic.Delete(_item.Id);
        }
        public static async Task<string> AddMessange(ConsoleMessangeViewModel _model)
        {
            ObservableCollection<Messange> _messangeGetTemp = new ObservableCollection<Messange>(await _messangeLogic.GetAsync());
            //id
            int _lastId = 0;
            for (int i = 0; i < _messangeGetTemp.Count; i++)
            {
                int _tempId = int.Parse(_messangeGetTemp[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            Messange _messNew = new Messange
            {
                Id = $"{_lastId}",
                TimeRequest = _model.TimeRequest,
                TextMessange = _model.TextMessange,
                LastTextMessange=_model.NewTextMessange,
                EmailSender = _model.EmailSender,
                UserRecipientMess = _model.UserRecipientMess
            };
            _messangeGet.Add(_messNew);
            _messangeLogic.Add(_messNew);
            return _messNew.TextMessange;


        }
        public static async Task<string> EditMessange(ConsoleMessangeViewModel _model)
        {
            ObservableCollection<Messange> _messangeGetTemp = new ObservableCollection<Messange>( await _messangeLogic.GetAsync());
            Messange _messNew = new Messange
            {
                Id = _model.Id,
                TimeRequest = _model.TimeRequest,
                TextMessange = _model.TextMessange,
                LastTextMessange=_model.NewTextMessange,
                EmailSender = _model.EmailSender,
                UserRecipientMess = _model.UserRecipientMess
            };
            //UI
            for (int i = 0; i < _messangeGetTemp.Count; i++)
            {
                if (_messangeGetTemp[i].Id == _messNew.Id)
                {
                    _messNew.TextMessange += _messangeGetTemp[i].TextMessange;
                    _messangeLogic.Edit(_messNew);
                }
            }
            return _messNew.TextMessange;

        }
        #endregion

        #region Main
        public static BitmapFrame LoadPhotoMain(byte[] _image)
        {
            ImageDataControlPhotoMain = _image;
            return ImageConvertor(_image);
        }
        public static BitmapFrame LoadLogoImg(byte[] _image)
        {
            ImageDataControlLogoImg = _image;
            return ImageConvertor(_image);
        }
        public static void NewImageMain()
        {
            ImageDataControlPhotoMain = NewImage();
            BitmapFrame _tempImage = ImageConvertor(ImageDataControlPhotoMain);
            if (_tempImage != null)
            {
                _modelConsol.PhotoMain = _tempImage;
            }
        }
        public static void NewImageLogo()
        {
            ImageDataControlLogoImg = NewImage();
            BitmapFrame _tempImage = ImageConvertor(ImageDataControlLogoImg);
            if (_tempImage != null)
            {
                _modelConsol.LogoImg = _tempImage;
            }
        }
        public static void SaveMain()
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _mainGet.Count; i++)
            {
                int _tempId = int.Parse(_mainGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_mainGet.Count == 0)
            {
                MainItem _tempItem = new MainItem
                {
                    Id = $"{_lastId}",
                    LabelH1TextBox = _modelConsol.LabelH1TextBox,
                    LabelH3TextBox = _modelConsol.LabelH3TextBox,
                    LabelDescriptionTextBox = _modelConsol.LabelDescriptionTextBox,
                    UserNameTextBox = _modelConsol.UserNameTextBox,
                    EmailTextBox = _modelConsol.EmailTextBox,
                    ButtonChatTextBox = _modelConsol.ButtonChatTextBox,
                    Data = ImageDataControlPhotoMain,
                    DataLogo= ImageDataControlLogoImg,
                    PhotoMain = ImageConvertor(ImageDataControlPhotoMain),
                    LogoImg = ImageConvertor(ImageDataControlLogoImg)
                };
                _mainLogic.Add(_tempItem);
            }
            else
            {
                for (int i = 0; i < _mainGet.Count; i++)
                {
                    _mainGet[i].LabelH1TextBox = _modelConsol.LabelH1TextBox;
                    _mainGet[i].LabelH3TextBox = _modelConsol.LabelH3TextBox;
                    _mainGet[i].LabelDescriptionTextBox = _modelConsol.LabelDescriptionTextBox;
                    _mainGet[i].UserNameTextBox = _modelConsol.UserNameTextBox;
                    _mainGet[i].EmailTextBox = _modelConsol.EmailTextBox;
                    _mainGet[i].ButtonChatTextBox = _modelConsol.ButtonChatTextBox;
                    _mainGet[i].Data = ImageDataControlPhotoMain;
                    _mainGet[i].DataLogo = ImageDataControlLogoImg;
                    _mainGet[i].PhotoMain = ImageConvertor(ImageDataControlPhotoMain);
                    _mainGet[i].LogoImg = ImageConvertor(ImageDataControlLogoImg);
                    _mainLogic.Edit(_mainGet[i]);
                }
            }
        }
        #endregion

        #region Project
        public static BitmapFrame NewProjectImage()
        {
            ImageDataControlImageProject = NewImage();
            return ImageConvertor(ImageDataControlImageProject);
        }
        public static ObservableCollection<ProjectItem> ProjectListView(ObservableCollection<ProjectItem> _projectGet)
        {
            for (int i = 0; i < _projectGet.Count; i++)
            {
                _projectGet[i].PhotoProject = ImageConvertor(_projectGet[i].Data);
            }
            return _projectGet;
        }
        public static void OpenViewProject(bool _mode, ProjectItem _item)
        {
            ViewProject _newViewProject = new ViewProject(InitializeProject(_mode, _item));
            _newViewProject.Show();
        }
        public static ProjectViewModel InitializeProject(bool _mode, ProjectItem _item)
        {
            ProjectViewModel _model = new ProjectViewModel();
            //mode true=newview
            if (_mode)
            {
                _model.Mode = true;
                _model.TitleProject = "Наименование";
                _model.DesriptionProject = "Описание";
                return _model;
            }
            else
            {
                _model.Mode = false;
                _model.Id = _item.Id;
                _model.TitleProject = _item.Title;
                _model.DesriptionProject = _item.Desription;
                _model.ImageProject = _item.PhotoProject;
                ImageDataControlImageProject = _item.Data;
                return _model;
            }
        }
        public static void AddEditProject(ProjectViewModel _dataItem)
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _projectGet.Count; i++)
            {
                int _tempId = int.Parse(_projectGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_dataItem.Mode)
            {
                ProjectItem _projectItem = new ProjectItem
                {
                    Id = $"{_lastId}",
                    Title = _dataItem.TitleProject,
                    Desription = _dataItem.DesriptionProject,
                    Data = ImageDataControlImageProject,
                    PhotoProject = ImageConvertor(ImageDataControlImageProject)
                };
                _projectGet.Add(_projectItem);
                _projectLogic.Add(_projectItem);
            }
            else
            {
                ProjectItem _projectItem = new ProjectItem
                {
                    Id = _dataItem.Id,
                    Title = _dataItem.TitleProject,
                    Desription = _dataItem.DesriptionProject,
                    Data = ImageDataControlImageProject,
                    PhotoProject = ImageConvertor(ImageDataControlImageProject)
                };
                for (int i = 0; i < _projectGet.Count; i++)
                {
                    if (_projectGet[i].Id == _projectItem.Id)
                    {
                        _projectGet.Insert(i, _projectItem);
                        _projectGet.RemoveAt(i + 1);
                    }
                }
                _projectLogic.Edit(_projectItem);
            }
        }
        public static void DeleteProject(ProjectItem _dataItem)
        {
            for (int i = 0; i < _projectGet.Count; i++)
            {
                if (_projectGet[i].Id == _dataItem.Id)
                {
                    _projectGet.RemoveAt(i);
                }
            }
            _projectLogic.Delete(_dataItem.Id);
        }
        #endregion

        #region Service
        public static void OpenViewService(bool _mode, ServiceItem _item)
        {
            ViewService _newViewBlog = new ViewService(InitializeService(_mode, _item));
            _newViewBlog.Show();
        }
        public static ServiceViewModel InitializeService(bool _mode, ServiceItem _item)
        {
            ServiceViewModel _model = new ServiceViewModel();
            //mode true=newview
            if (_mode)
            {
                _model.Mode = true;
                _model.TitleService = "Наименование";
                _model.DesriptionService = "Описание";
                return _model;
            }
            else
            {
                _model.Mode = false;
                _model.Id = _item.Id;
                _model.TitleService = _item.TitleService;
                _model.DesriptionService = _item.DesriptionService;
                return _model;
            }
        }
        public static void AddEditService(ServiceViewModel _dataItem)
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _serviceGet.Count; i++)
            {
                int _tempId = int.Parse(_serviceGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_dataItem.Mode)
            {
                ServiceItem _item = new ServiceItem
                {
                    Id = $"{_lastId}",
                    TitleService = _dataItem.TitleService,
                    DesriptionService = _dataItem.DesriptionService
                };
                _serviceGet.Add(_item);
                _serviceLogic.Add(_item);
            }
            else
            {
                ServiceItem _item = new ServiceItem
                {
                    Id = _dataItem.Id,
                    TitleService = _dataItem.TitleService,
                    DesriptionService = _dataItem.DesriptionService
                };
                for (int i = 0; i < _serviceGet.Count; i++)
                {
                    if (_serviceGet[i].Id == _item.Id)
                    {
                        _serviceGet.Insert(i, _item);
                        _serviceGet.RemoveAt(i + 1);
                    }
                }
                _serviceLogic.Edit(_item);
            }
        }

        public static void DeleteService(ServiceItem _dataItem)
        {
            for (int i = 0; i < _serviceGet.Count; i++)
            {
                if (_serviceGet[i].Id == _dataItem.Id)
                {
                    _serviceGet.RemoveAt(i);
                }
            }
            _serviceLogic.Delete(_dataItem.Id);
        }
        #endregion

        #region Blog
        public static BitmapFrame NewBlogImage()
        {
            ImageDataControlPhotoBlog = NewImage();
            return ImageConvertor(ImageDataControlPhotoBlog);
        }
        public static ObservableCollection<BlogItem> BlogtListView(ObservableCollection<BlogItem> _blogGet)
        {
            for (int i = 0; i < _blogGet.Count; i++)
            {
                _blogGet[i].PhotoBlog = ImageConvertor(_blogGet[i].Data);
            }
            return _blogGet;
        }
        public static void OpenViewBlog(bool _mode, BlogItem _item)
        {
            ViewBlog _newViewBlog = new ViewBlog(InitializeBlog(_mode, _item));
            _newViewBlog.Show();
        }
        public static BlogViewModel InitializeBlog(bool _mode, BlogItem _item)
        {
            BlogViewModel _model = new BlogViewModel();
            //mode true=newview
            if (_mode)
            {
                _model.Mode = true;
                DateTime _now = DateTime.Now;
                _model.DateBlog = $"{_now}";
                _model.TitleBlog = "Наименование";
                _model.DesriptionBlog = "Описание";
                return _model;
            }
            else
            {
                _model.Mode = false;
                _model.Id = _item.Id;
                _model.DateBlog = _item.DateBlog;
                _model.TitleBlog = _item.TitleBlog;
                _model.DesriptionBlog = _item.DesriptionBlog;
                _model.PhotoBlog = _item.PhotoBlog;
                ImageDataControlPhotoBlog = _item.Data;
                return _model;
            }
        }
        public static void AddEditBlog(BlogViewModel _dataItem)
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _blogGet.Count; i++)
            {
                int _tempId = int.Parse(_blogGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_dataItem.Mode)
            {
                BlogItem _blogItem = new BlogItem
                {
                    Id = $"{_lastId}",
                    DateBlog = _dataItem.DateBlog,
                    TitleBlog = _dataItem.TitleBlog,
                    DesriptionBlog = _dataItem.DesriptionBlog,
                    Data = ImageDataControlPhotoBlog,
                    PhotoBlog = ImageConvertor(ImageDataControlPhotoBlog)
                };
                _blogGet.Add(_blogItem);
                _blogLogic.Add(_blogItem);
            }
            else
            {
                BlogItem _blogItem = new BlogItem
                {
                    Id = _dataItem.Id,
                    DateBlog = _dataItem.DateBlog,
                    TitleBlog = _dataItem.TitleBlog,
                    DesriptionBlog = _dataItem.DesriptionBlog,
                    Data = ImageDataControlPhotoBlog,
                    PhotoBlog = ImageConvertor(ImageDataControlPhotoBlog)
                };
                for (int i = 0; i < _blogGet.Count; i++)
                {
                    if (_blogGet[i].Id == _blogItem.Id)
                    {
                        _blogGet.Insert(i, _blogItem);
                        _blogGet.RemoveAt(i + 1);
                    }
                }
                _blogLogic.Edit(_blogItem);
            }
        }

        public static void DeleteBlog(BlogItem _dataItem)
        {
            for (int i = 0; i < _blogGet.Count; i++)
            {
                if (_blogGet[i].Id == _dataItem.Id)
                {
                    _blogGet.RemoveAt(i);
                }
            }
            _blogLogic.Delete(_dataItem.Id);
        }
        #endregion

        #region Contact
        public static BitmapFrame ImageContact(ObservableCollection<ContactItem> _contactGet)
        {
            BitmapFrame _image = null;
            for (int i = 0; i < _contactGet.Count; i++)
            {
                ImageDataControlContactImg = _contactGet[i].Data;
                _image = ImageConvertor(_contactGet[i].Data);
            }
            return _image;
        }
        public static string TextContactA(ObservableCollection<ContactItem> _contactGet)
        {
            string _text = "";
            for (int i = 0; i < _contactGet.Count; i++)
            {
                _text = _contactGet[i].TextContactA;
            }
            return _text;
        }
        public static string TextContactB(ObservableCollection<ContactItem> _contactGet)
        {
            string _text = "";
            for (int i = 0; i < _contactGet.Count; i++)
            {
                _text = _contactGet[i].TextContactB;
            }
            return _text;
        }
        public static string TextContactC(ObservableCollection<ContactItem> _contactGet)
        {
            string _text = "";
            for (int i = 0; i < _contactGet.Count; i++)
            {
                _text = _contactGet[i].TextContactC;
            }
            return _text;
        }
        public static void NewImageContact()
        {
            ImageDataControlContactImg = NewImage();
            BitmapFrame _tempImage = ImageConvertor(ImageDataControlContactImg);
            if (_tempImage != null)
            {
                _modelConsol.ImageContact = _tempImage;
            }
        }
        public static void SaveContact()
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _contactGet.Count; i++)
            {
                int _tempId = int.Parse(_contactGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_contactGet.Count == 0)
            {
                ContactItem _tempItem = new ContactItem
                {
                    Id = $"{_lastId}",
                    TextContactA = _modelConsol.TextContactA,
                    TextContactB = _modelConsol.TextContactB,
                    TextContactC = _modelConsol.TextContactC,
                    Data = ImageDataControlContactImg
                };
                _contactLogic.Add(_tempItem);
            }
            else
            {
                for (int i = 0; i < _contactGet.Count; i++)
                {
                    _contactGet[i].TextContactA = _modelConsol.TextContactA;
                    _contactGet[i].TextContactB = _modelConsol.TextContactB;
                    _contactGet[i].TextContactC = _modelConsol.TextContactC;
                    _contactGet[i].Data = ImageDataControlContactImg;
                    _contactLogic.Edit(_contactGet[i]);
                }
            }
        }
        #endregion

        #region Link
        public static BitmapFrame NewLinkImage()
        {
            ImageDataControlLinkImg = NewImage();
            return ImageConvertor(ImageDataControlLinkImg);
        }
        public static ObservableCollection<LinkItem> LinkListView(ObservableCollection<LinkItem> _linkGet)
        {
            for (int i = 0; i < _linkGet.Count; i++)
            {
                _linkGet[i].ImageLink = ImageConvertor(_linkGet[i].Data);
            }
            return _linkGet;
        }

        public static void OpenViewLink()
        {
            ViewLink _newViewLink = new ViewLink(InitializeLink());
            _newViewLink.Show();
        }
        public static LinkViewModel InitializeLink()
        {
            LinkViewModel _model = new LinkViewModel();
            _model.LinkListView = _linkGet;
            return _model;
        }
        public static void AddEditLink(LinkItem _dataItem, LinkViewModel _model)
        {
            //id
            int _lastId = 0;
            for (int i = 0; i < _linkGet.Count; i++)
            {
                int _tempId = int.Parse(_linkGet[i].Id);

                if (_lastId < _tempId)
                {
                    _lastId = _tempId;
                }
            }
            _lastId++;
            //
            if (_model.Mode)
            {
                LinkItem _linkItem = new LinkItem
                {
                    Id = $"{_lastId}",
                    Url = "ссылка//",
                };
                _linkLogic.Add(_linkItem);
                _model.LinkListView.Add(_linkItem);
            }
            else
            {
                _dataItem.Data = ImageDataControlLinkImg;
                _linkLogic.Edit(_dataItem);
            }
        }
        public static void DeleteLink(LinkItem _dataItem, LinkViewModel _model)
        {
            _linkLogic.Delete(_dataItem.Id);
            _model.LinkListView.Remove(_dataItem);
        }
        #endregion
    }
}
