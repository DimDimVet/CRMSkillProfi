using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace AdminConsol.View
{
    public partial class ViewUserCard : Window
    {
        private bool _flagNewEdit;//true=new 
        private bool _flagMode;//true=find 
        public ViewUserCard(UserCardViewModel _model,bool flagMode)
        {
            InitializeComponent();
            DataContext = _model;
            _flagNewEdit = _model.Mode;
            this._flagMode = flagMode;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            UserCardViewModel _model = (UserCardViewModel)DataContext;
            if (_flagNewEdit)
            {
                Logic.AddUser(_model);
            }
            else
            {
                Logic.EditUser(_model);
            }
            Close();
        }

        public void FindButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.Find((UserCardViewModel)DataContext);
            Close();
        }
        //
        private void UserSurNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = true;
                UserNameTextBox.IsEnabled = false;
                UserMiddleNameTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = false;
                PhoneNumberTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = false;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void UserNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = false;
                UserNameTextBox.IsEnabled = true;
                UserMiddleNameTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = false;
                PhoneNumberTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = false;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void UserMiddleNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = false;
                UserNameTextBox.IsEnabled = false;
                UserMiddleNameTextBox.IsEnabled = true;
                EmailTextBox.IsEnabled = false;
                PhoneNumberTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = false;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = false;
                UserNameTextBox.IsEnabled = false;
                UserMiddleNameTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = true;
                PhoneNumberTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = false;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void PhoneNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = false;
                UserNameTextBox.IsEnabled = false;
                UserMiddleNameTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = false;
                PhoneNumberTextBox.IsEnabled = true;
                AddressTextBox.IsEnabled = false;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void AddressTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (_flagMode)
            {
                UserSurNameTextBox.IsEnabled = false;
                UserNameTextBox.IsEnabled = false;
                UserMiddleNameTextBox.IsEnabled = false;
                EmailTextBox.IsEnabled = false;
                PhoneNumberTextBox.IsEnabled = false;
                AddressTextBox.IsEnabled = true;
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
        private void Esc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                UserSurNameTextBox.IsEnabled = true; UserSurNameTextBox.Text = "";
                UserNameTextBox.IsEnabled = true; UserNameTextBox.Text = "";
                UserMiddleNameTextBox.IsEnabled = true; UserMiddleNameTextBox.Text = "";
                EmailTextBox.IsEnabled = true; EmailTextBox.Text = "";
                PhoneNumberTextBox.IsEnabled = true; PhoneNumberTextBox.Text = "";
                AddressTextBox.IsEnabled = true; AddressTextBox.Text = "";
                RoleTextBox.IsEnabled = false;
                DesriptionTextBox.IsEnabled = false;
            }
        }
    }
}
