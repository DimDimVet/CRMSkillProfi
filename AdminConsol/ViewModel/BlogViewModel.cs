using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace AdminConsol.ViewModel
{
    public class BlogViewModel : INotifyPropertyChanged
    {
        private string dataBlog;
        private string titleBlog;
        private string desriptionBlog;
        private BitmapFrame photoBlog;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public byte[] DataImage { get; set; }
        public string DateBlog
        {
            get { return dataBlog; }
            set 
            {
                dataBlog = value;
                OnPropertyChanged("DateBlog");
            }
        }

        public string TitleBlog
        {
            get { return titleBlog; }
            set 
            {
                titleBlog = value;
                OnPropertyChanged("TitleBlog");
            }
        }
        public string DesriptionBlog
        {
            get { return desriptionBlog; }
            set
            {
                desriptionBlog = value;
                OnPropertyChanged("DesriptionBlog");
            }
        }
        
        public BitmapFrame PhotoBlog
        {
            get { return photoBlog; }
            set
            {
                photoBlog = value;
                OnPropertyChanged("PhotoBlog");
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
