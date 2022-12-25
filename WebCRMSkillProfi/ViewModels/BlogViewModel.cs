using System.Collections.ObjectModel;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.ViewModels
{
    public class BlogViewModel
    {
        public ObservableCollection<BlogItem> _BlogList { get; set; }
        public string GetId { get; set; }
        public BlogItem _Item { get; set; }
        public string _imagePath { get; set; }
    }
}
