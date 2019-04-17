using System.Windows;
using Lab4_Mysko.Managers;
using Lab4_Mysko.Models;

namespace Lab4_Mysko
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Storage data = new Storage("..\\..\\SerializedData\\users.bin");
            MainWindow mainWindow = new MainWindow(data);
            NavigationManager.Instance.Initialise(new NavigationModel(mainWindow, data));
            NavigationManager.Instance.Navigate(Models.Views.UsersView);
            mainWindow.Show();
        }
    }
}