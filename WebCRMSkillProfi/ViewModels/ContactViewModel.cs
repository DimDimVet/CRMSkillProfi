using System.Collections.ObjectModel;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.ViewModels
{
    public class ContactViewModel
    {
        public string _TextContactA { get; set; }
        public string _TextContactB { get; set; }
        public string _TextContactC { get; set; }
        public string _imagePath { get; set; }
        public string ImageContactPath { get; set; }
        public ObservableCollection<LinkItem> _Link { get; set; }
    }
}
