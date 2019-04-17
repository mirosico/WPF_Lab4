using System.ComponentModel;
using System.Windows;
using Lab4_Mysko.Managers;
using Lab4_Mysko.Models;

namespace Lab4_Mysko
{
    public partial class MainWindow : Window
    {
        private Storage _data;

        public MainWindow(Storage data)
        {
            _data = data;
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SerializationManager.Serialise("..\\..\\SerializedData\\users.bin", _data.Users);
            base.OnClosing(e);
        }
    }
}