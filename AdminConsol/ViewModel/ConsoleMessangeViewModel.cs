using AdminConsol.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminConsol.ViewModel
{
    public class ConsoleMessangeViewModel : INotifyPropertyChanged
    {

        private string textMessange;
        private string newTextMessange;
        private ObservableCollection<User> emailComboBox;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public string TimeRequest { get; set; }
        public string EmailSender { get; set; }
        public string UserRecipientMess { get; set; }
        public string TextMessange
        {
            get { return textMessange; }
            set
            {
                textMessange = value;
                OnPropertyChanged("TextMessange");
            }
        }

        public string NewTextMessange
        {
            get { return newTextMessange; }
            set
            {
                newTextMessange = value;
                OnPropertyChanged("NewTextMessange");
            }
        }
        public ObservableCollection<User> EmailComboBox
        {
            get { return emailComboBox; }
            set
            {
                emailComboBox = value;
                OnPropertyChanged("EmailComboBox");
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
