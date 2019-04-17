using System;
using Lab4_Mysko.Views;

namespace Lab4_Mysko.Models
{
    public enum Views
    {
        UserInputView,
        UserInfoView,
        UsersView
    }

    class NavigationModel
    {
        private MainWindow _window;
        private UserInputView _UserInputView;
        private UserInfoView _userInfoView;
        private UsersView _usersView;

        public NavigationModel(MainWindow window, Storage data)
        {
            _window = window;
            _UserInputView = new UserInputView(data);
            _userInfoView = new UserInfoView(data);
            _usersView = new UsersView(data);
        }

        public void Navigate(Views view)
        {
            switch (view)
            {
                case Views.UserInputView:
                    _window.Title = "Input";
                    _window.MinWidth = 400;
                    _window.MinHeight = 371;
                    _window.WindowContents.Content = _UserInputView;
                    break;
                case Views.UserInfoView:
                    _window.Title = "Info";
                    _window.MinHeight = 400;
                    _window.WindowContents.Content = _userInfoView;
                    break;
                case Views.UsersView:
                    _window.Title = "Users";
                    _window.MinHeight = 200;
                    _window.MaxHeight = 500;
                    _window.MinWidth = 750;
                    _window.MaxWidth = 900;
                    _window.WindowContents.Content = _usersView;
                    break;
                default:
                    throw new ArgumentException("Inappropriate parameter for navigation !");
            }
        }
    }
}