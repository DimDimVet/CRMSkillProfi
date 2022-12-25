
using System.Windows.Media.Imaging;

namespace AdminConsol.Models
{
    class ProjectItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Desription { get; set; }
        public byte[] Data { get; set; }
        public BitmapFrame PhotoProject { get; set; }
    }
}
