using AdminConsol.Models;
using AdminConsol.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace AdminConsol.View
{
    public partial class ViewLink : Window
    {
        LinkViewModel _model;
        public ViewLink(LinkViewModel model)
        {
            InitializeComponent();
            this._model = model;
            DataContext = _model;
        }
        private void AddLinkButton_Click(object sender, RoutedEventArgs e)
        {
            _model = (LinkViewModel)DataContext;
            _model.Mode = true;
            Logic.AddEditLink(null, _model);
        }

        private void ImgLinkButton_Click(object sender, RoutedEventArgs e)
        {
            LinkItem _modelItem = (LinkItem)((ListViewItem)LinkListView.ContainerFromElement((Button)sender)).Content;
            _modelItem.ImageLink =Logic.NewLinkImage();
            _model.LinkListView.Add(_modelItem);
            _model.LinkListView.Remove(_modelItem);
        }
        private void DeleteLinkButton_Click(object sender, RoutedEventArgs e)
        {
            LinkItem _item = (LinkItem)((ListViewItem)LinkListView.ContainerFromElement((Button)sender)).Content;
            _model = (LinkViewModel)DataContext;
            Logic.DeleteLink(_item, _model);
        }

        private void SaveLinkButton_Click(object sender, RoutedEventArgs e)
        {
            LinkItem _item = (LinkItem)((ListViewItem)LinkListView.ContainerFromElement((Button)sender)).Content;
            _model = (LinkViewModel)DataContext;
            _model.Mode = false;
            Logic.AddEditLink(_item, _model);
        }
    }
}
