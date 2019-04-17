using System.Windows.Controls;
using Lab4_Mysko.Models;
using Lab4_Mysko.ViewModels;

namespace Lab4_Mysko.Views
{
    /// <summary>
    /// Interaction logic for UserInputView.xaml
    /// </summary>
    public partial class UserInputView : UserControl
    {
        private UserInputViewModel _model;

        public UserInputView(Storage data)
        {
            InitializeComponent();

            _model = new UserInputViewModel(data);
            DataContext = _model;
        }

        
    }
}