using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace AdminConsol.ViewModel
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        private string titleProject;
        private string desriptionProject;
        private BitmapFrame imageProject;
        //
        public bool Mode { get; set; }
        public string Id { get; set; }
        public byte[] DataImage { get; set; }
        public string TitleProject
        {
            get { return titleProject; }
            set
            {
                titleProject = value;
                OnPropertyChanged("TitleProject");
            }
        }
        public string DesriptionProject
        {
            get { return desriptionProject; }
            set
            {
                desriptionProject = value;
                OnPropertyChanged("DesriptionProject");
            }
        }

        public BitmapFrame ImageProject
        {
            get { return imageProject; }
            set
            {
                imageProject = value;
                OnPropertyChanged("ImageProject");
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
