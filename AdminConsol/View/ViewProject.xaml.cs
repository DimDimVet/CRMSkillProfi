using AdminConsol.Interfaces;
using AdminConsol.Models;
using AdminConsol.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AdminConsol.View
{
    public partial class ViewProject : Window
    {
        public ViewProject(ProjectViewModel _model)
        {
            InitializeComponent();
            DataContext = _model;
        }

        private void NewImageButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectViewModel _model = (ProjectViewModel)DataContext;
            _model.ImageProject =Logic.NewProjectImage();
            DataContext = _model;
        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            ProjectViewModel _model = (ProjectViewModel)DataContext;
            Logic.AddEditProject(_model);
            Close();
        }
    }
}
