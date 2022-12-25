using System.Windows.Media.Imaging;

namespace AdminConsol.Models
{
    class ContactItem 
    {
        public string Id { get; set; }
        public string TextContactA { get; set; }
        public string TextContactB { get; set; }
        public string TextContactC { get; set; }
        public byte[] Data { get; set; }
        public BitmapFrame ImageContact { get; set; }
    }
}

