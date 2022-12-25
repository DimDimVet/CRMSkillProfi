using AdminConsol.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminConsol.ViewModel
{
    public class UserCardViewModel : INotifyPropertyChanged
    {
        private string userSurName;
        private string userName;
        private string userMiddleName;
        private string email;
        private string phoneNumber;
        private string address;
        private string role;
        private string desription;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public string UserSurName
        {
            get { return userSurName; }
            set
            {
                userSurName = value;
                OnPropertyChanged("UserSurName");
            }
        }

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }
        public string UserMiddleName
        {
            get { return userMiddleName; }
            set
            {
                userMiddleName = value;
                OnPropertyChanged("UserMiddleName");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Role
        {
            get { return role; }
            set
            {
                role = value;
                OnPropertyChanged("Role");
            }
        }
        public string Desription
        {
            get { return desription; }
            set
            {
                desription = value;
                OnPropertyChanged("Desription");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static explicit operator UserCardViewModel(User v)
        {
            throw new NotImplementedException();
        }
    }
}
