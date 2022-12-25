using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;

namespace AdminConsol.View
{
    public partial class ViewService : Window
    {
        public ViewService(ServiceViewModel _model)
        {
            InitializeComponent();
            DataContext = _model;
        }
        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceViewModel _model = (ServiceViewModel)DataContext;
            Logic.AddEditService(_model);
            Close();
        }
    }
}
