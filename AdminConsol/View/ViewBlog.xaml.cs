using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;

namespace AdminConsol.View
{
    public partial class ViewBlog : Window
    {
        public ViewBlog(BlogViewModel _model)
        {
            InitializeComponent();
            DataContext = _model;
        }
        private void NewImageButton_Click(object sender, RoutedEventArgs e)
        {
            BlogViewModel _model = (BlogViewModel)DataContext;
            _model.PhotoBlog= Logic.NewBlogImage();
            DataContext = _model;
        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            BlogViewModel _model = (BlogViewModel)DataContext;
            Logic.AddEditBlog(_model);
            Close();
        }
    }
}
