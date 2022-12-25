using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;

namespace AdminConsol
{
    public partial class ViewConsole : Window
    {
        public ViewConsole()
        {
            InitializeComponent();
            DataContext = Logic.InitializeConsol();
        }

        #region TabConsol
        private void TableUserButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewUser();
        }
        private void AddMessenge_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewMessange(null);
        }
        private void RefButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.RefMessange();
        }
        private void ListMessange_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if ((Messange)ListMessange.SelectedItem != null)
            {
                Messange _selectItem = (Messange)ListMessange.SelectedItem;
                Logic.OpenViewMessange(_selectItem);
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if ((Messange)ListMessange.SelectedItem != null)
            {
                Messange _selectItem = (Messange)ListMessange.SelectedItem;
                Logic.DeleteChat(_selectItem);
            }
        }
        #endregion

        #region Main
        private void ButtonNewImageMain_Click(object sender, RoutedEventArgs e)
        {
            Logic.NewImageMain();
        }
        private void ButtonNewImageLogo_Click(object sender, RoutedEventArgs e)
        {
            Logic.NewImageLogo();
        }

        private void ButtonSaveMain_Click(object sender, RoutedEventArgs e)
        {
            Logic.SaveMain();
        }
        #endregion

        #region Project

        private void AddProject_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewProject(true, null);
        }

        private void EditProject_Click(object sender, RoutedEventArgs e)
        {
            if ((ProjectItem)ProjectListView.SelectedItem != null)
            {
                ProjectItem _selectItem = (ProjectItem)ProjectListView.SelectedItem;
                Logic.OpenViewProject(false, _selectItem);
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if ((ProjectItem)ProjectListView.SelectedItem != null)
            {
                ProjectItem _selectItem = (ProjectItem)ProjectListView.SelectedItem;
                Logic.DeleteProject(_selectItem);
            }
        }
        #endregion

        #region Service
        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewService(true, null);
        }
        private void EditService_Click(object sender, RoutedEventArgs e)
        {
            if ((ServiceItem)ServiceListView.SelectedItem != null)
            {
                ServiceItem _selectItem = (ServiceItem)ServiceListView.SelectedItem;
                Logic.OpenViewService(false, _selectItem);
            }
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            if ((ServiceItem)ServiceListView.SelectedItem != null)
            {
                ServiceItem _selectItem = (ServiceItem)ServiceListView.SelectedItem;
                Logic.DeleteService(_selectItem);
            }
        }
        #endregion

        #region Blog
        private void AddBlog_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewBlog(true, null);
        }

        private void EditBlog_Click(object sender, RoutedEventArgs e)
        {
            if ((BlogItem)BlogtListView.SelectedItem != null)
            {
                BlogItem _selectItem = (BlogItem)BlogtListView.SelectedItem;
                Logic.OpenViewBlog(false, _selectItem);
            }
        }

        private void DeleteBlog_Click(object sender, RoutedEventArgs e)
        {
            if ((BlogItem)BlogtListView.SelectedItem != null)
            {
                BlogItem _selectItem = (BlogItem)BlogtListView.SelectedItem;
                Logic.DeleteBlog(_selectItem);
            }
        }
        #endregion

        #region Contact
        private void ButtonNewImageContact_Click(object sender, RoutedEventArgs e)
        {
            Logic.NewImageContact();
        }
        private void ButtonLinkContact_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewLink();
        }
        private void ButtonSaveContact_Click(object sender, RoutedEventArgs e)
        {
            Logic.SaveContact();
        }
        #endregion
    }
}
