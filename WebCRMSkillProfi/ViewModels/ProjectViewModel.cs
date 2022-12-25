using System.Collections.ObjectModel;
using WebCRMSkillProfi.Models;

namespace WebCRMSkillProfi.ViewModels
{
    public class ProjectViewModel
    {
        public ObservableCollection<ProjectItem> _ProjectList { get; set; }
        public ProjectItem _Item { get; set; }
        public string GetId { get; set; }
        public string _imagePath { get; set; }
    }
}
