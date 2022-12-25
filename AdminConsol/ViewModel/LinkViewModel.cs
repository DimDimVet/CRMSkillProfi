using AdminConsol.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace AdminConsol.ViewModel
{
    public class LinkViewModel:INotifyPropertyChanged
    {
        private string url;
        private BitmapFrame imageLink;
        private ObservableCollection<LinkItem> linkListView;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public byte[] DataImage { get; set; }
        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                OnPropertyChanged("DateBlog");
            }
        }
        
        public BitmapFrame ImageLink
        {
            get { return imageLink; }
            set
            {
                imageLink = value;
                OnPropertyChanged("ImageLink");
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
