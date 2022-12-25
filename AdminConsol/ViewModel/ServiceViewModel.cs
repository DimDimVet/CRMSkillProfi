using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminConsol.ViewModel
{
    public class ServiceViewModel : INotifyPropertyChanged
    {
        private string titleService;
        private string desriptionService;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public string TitleService
        {
            get { return titleService; }
            set
            {
                titleService = value;
                OnPropertyChanged("TitleService");
            }
        }

        public string DesriptionService
        {
            get { return desriptionService; }
            set
            {
                desriptionService = value;
                OnPropertyChanged("DesriptionService");
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
