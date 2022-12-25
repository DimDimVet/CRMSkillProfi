using System.Collections.ObjectModel;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.ViewModels
{
    public class ServiceViewModel
    {
        public ObservableCollection<ServiceItem> _ServiceList { get; set; }
        public string _imagePath { get; set; }
    }
}
