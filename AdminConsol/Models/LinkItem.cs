
using System.Windows.Media.Imaging;

namespace AdminConsol.Models
{
    public class LinkItem
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public byte[] Data { get; set; }
        public BitmapFrame ImageLink { get; set; }
    }
}
