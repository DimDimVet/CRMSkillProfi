
using System.Windows.Media.Imaging;

namespace AdminConsol.Models
{
    class BlogItem 
    {
        public string Id { get; set; }
        public string TitleBlog { get; set; }
        public string DateBlog { get; set; }
        public string DesriptionBlog { get; set; }
        public byte[] Data { get; set; }
        public BitmapFrame PhotoBlog { get; set; }
    }
}
