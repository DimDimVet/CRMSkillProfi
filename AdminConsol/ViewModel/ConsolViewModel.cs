using AdminConsol.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace AdminConsol.ViewModel
{
    class ConsolViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Messange> listMessange;
        private string labelH1TextBox;
        private string labelH3TextBox;
        private string labelDescriptionTextBox;
        private string userNameTextBox;
        private string emailTextBox;
        private string buttonChatTextBox;
        private BitmapFrame photoMain;
        private BitmapFrame logoImg;

        private ObservableCollection<ProjectItem> projectListView;

        private ObservableCollection<ServiceItem> serviceListView;

        private ObservableCollection<BlogItem> blogtListView;

        private BitmapFrame imageContact;
        private string textContactA;
        private string textContactB;
        private string textContactC;

        private ObservableCollection<LinkItem> linkListView;
        //
        public string Id { get; set; }
        public byte[] DataImage { get; set; }
        public ObservableCollection<Messange> ListMessange
        {
            get { return listMessange; }
            set
            {
                listMessange = value;
                OnPropertyChanged("ListMessange");
            }
        }
        public string LabelH1TextBox
        {
            get { return labelH1TextBox; }
            set
            {
                labelH1TextBox = value;
                OnPropertyChanged("LabelH1TextBox");
            }
        }
        public string LabelH3TextBox
        {
            get { return labelH3TextBox; }
            set
            {
                labelH3TextBox = value;
                OnPropertyChanged("LabelH3TextBox");
            }
        }
        public string LabelDescriptionTextBox
        {
            get { return labelDescriptionTextBox; }
            set
            {
                labelDescriptionTextBox = value;
                OnPropertyChanged("LabelDescriptionTextBox");
            }
        }
        public string UserNameTextBox
        {
            get { return userNameTextBox; }
            set
            {
                userNameTextBox = value;
                OnPropertyChanged("UserNameTextBox");
            }
        }
        public string EmailTextBox
        {
            get { return emailTextBox; }
            set
            {
                emailTextBox = value;
                OnPropertyChanged("EmailTextBox");
            }
        }
        public string ButtonChatTextBox
        {
            get { return buttonChatTextBox; }
            set
            {
                buttonChatTextBox = value;
                OnPropertyChanged("ButtonChatTextBox");
            }
        }

        public BitmapFrame PhotoMain
        {
            get { return photoMain; }
            set
            {
                photoMain = value;
                OnPropertyChanged("PhotoMain");
            }
        }
        public BitmapFrame LogoImg
        {
            get { return logoImg; }
            set
            {
                logoImg = value;
                OnPropertyChanged("LogoImg");
            }
        }
        public ObservableCollection<ProjectItem> ProjectListView
        {
            get { return projectListView; }
            set
            {
                projectListView = value;
                OnPropertyChanged("ProjectListView");
            }
        }
        public ObservableCollection<ServiceItem> ServiceListView
        {
            get { return serviceListView; }
            set
            {
                serviceListView = value;
                OnPropertyChanged("ServiceListView");
            }
        }
        public ObservableCollection<BlogItem> BlogtListView
        {
            get { return blogtListView; }
            set
            {
                blogtListView = value;
                OnPropertyChanged("BlogtListView");
            }
        }
        public BitmapFrame ImageContact
        {
            get { return imageContact; }
            set
            {
                imageContact = value;
                OnPropertyChanged("ImageContact");
            }
        }
        public string TextContactA
        {
            get { return textContactA; }
            set
            {
                textContactA = value;
                OnPropertyChanged("TextContactA");
            }
        }
        public string TextContactB
        {
            get { return textContactB; }
            set
            {
                textContactB = value;
                OnPropertyChanged("TextContactB");
            }
        }
        public string TextContactC
        {
            get { return textContactC; }
            set
            {
                textContactC = value;
                OnPropertyChanged("TextContactC");
            }
        }
        public ObservableCollection<LinkItem> LinkListView
        {
            get { return linkListView; }
            set
            {
                linkListView = value;
                OnPropertyChanged("LinkListView");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
