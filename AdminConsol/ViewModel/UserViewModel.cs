using AdminConsol.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminConsol.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> userListView;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public ObservableCollection<User> UserListView
        {
            get { return userListView; }
            set
            {
                userListView = value;
                OnPropertyChanged("UserListView");
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
