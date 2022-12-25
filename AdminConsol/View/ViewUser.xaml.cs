using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;

namespace AdminConsol.View
{
    public partial class ViewUser : Window
    {
        public ViewUser(UserViewModel _model)
        {
            InitializeComponent();
            DataContext= _model;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.OpenViewUserCard(null);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if ((User)UserListView.SelectedItem != null)
            {
                Logic.OpenViewUserCard((User)UserListView.SelectedItem);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if ((User)UserListView.SelectedItem != null)
            {
                Logic.DeleteUser((User)UserListView.SelectedItem);
            }
        }
        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.FindWinUser();
        }

        private void RefButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.RefCollection();
        }
        private void UserSurName_Click(object sender, RoutedEventArgs e)
        {
           Logic.SortData("UserSurName");
        }

        private void UserName_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("UserName");
        }
        private void Id_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("Id");
        }
        private void UserMiddleName_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("UserMiddleName");
        }
        private void Email_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("Email");
        }
        private void PhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("PhoneNumber");
        }
        private void Address_Click(object sender, RoutedEventArgs e)
        {
            Logic.SortData("Address");
        }
        private void Role_Click(object sender, RoutedEventArgs e)
        {
           Logic.SortData("Role");
        }
    }
}
