using System.Windows.Controls;
using Lab4_Mysko.Models;
using Lab4_Mysko.ViewModels;

namespace Lab4_Mysko.Views
{
    /// <summary>
    /// Interaction logic for UserInfoView.xaml
    /// </summary>
    public partial class UserInfoView : UserControl
    {
        private UserInfoViewModel _model;

        public UserInfoView(Storage data)
        {
            InitializeComponent();
            _model = new UserInfoViewModel(data);
            DataContext = _model;
        }
    }
}