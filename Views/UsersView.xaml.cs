using System.Windows.Controls;
using Lab4_Mysko.Models;
using Lab4_Mysko.ViewModels;

namespace Lab4_Mysko.Views
{
    /// <summary>
    /// Interaction logic for UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        private UsersViewModel _model;

        public UsersView(Storage data)
        {
            InitializeComponent();

            _model = new UsersViewModel(data);
            DataContext = _model;
        }

        private void OnUsersSorting(object sender, DataGridSortingEventArgs e)
        {
        }
    }
}