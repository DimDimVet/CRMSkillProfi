using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;

namespace AdminConsol.View
{
    public partial class ViewConsoleMessange : Window
    {
        private bool _flagMode;//true=AddMessange 
        ConsoleMessangeViewModel _model;
        public ViewConsoleMessange(ConsoleMessangeViewModel model)
        {
            _model = new ConsoleMessangeViewModel();
            this._model = model;
            InitializeComponent();
            DataContext = _model;
            _flagMode = _model.Mode;
            SetComboBox(_model);
        }
        private void SetComboBox(ConsoleMessangeViewModel model)
        {
            EmailComboBox.ItemsSource = _model.EmailComboBox;
            if (_flagMode == false)
            {
                for (int i = 0; i < EmailComboBox.Items.Count; i++)
                {
                    User _forTemp = (User)EmailComboBox.Items[i];
                    if (_forTemp.Email == _model.UserRecipientMess)
                    {
                        EmailComboBox.SelectedIndex = i;
                    }
                }
            }
        }
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ConsoleMessangeViewModel _model = new ConsoleMessangeViewModel();
            if (_flagMode)
            {
                 _model=(ConsoleMessangeViewModel)DataContext;
                _model.UserRecipientMess= ((User)EmailComboBox.SelectedItem).Email;
                string _complexText = $"{_model.TimeRequest}\n " +
                                      $"{Option.UserName} -> {NewTextMessangeTextBox.Text}\n\n";
                _model.TextMessange = _complexText;
                _model.TextMessange=await Logic.AddMessange(_model);
            }
            else
            {
                _model = (ConsoleMessangeViewModel)DataContext;
                _model.UserRecipientMess = ((User)EmailComboBox.SelectedItem).Email;
                _model.TextMessange = $"{_model.TimeRequest}\n " +
                                      $"{Option.UserName} -> {NewTextMessangeTextBox.Text}\n\n";
                _model.TextMessange =await Logic.EditMessange(_model);
            }
        }
    }
}
