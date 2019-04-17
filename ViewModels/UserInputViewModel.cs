using System;
using System.Windows;
using System.Windows.Input;
using Lab4_Mysko.Managers;
using Lab4_Mysko.Models;
using Lab4_Mysko.Tools;

namespace Lab4_Mysko.ViewModels
{
    public enum UserEditMode
    {
        Add,
        Edit
    }

    public class UserInputViewModel : ObservableItem
    {
        public static UserEditMode EditMode = UserEditMode.Add;
        private string _name, _surname, _email;
        private DateTime _date;

        private ICommand _processCommand;

        public UserInputViewModel(Storage data)
        {
            _name = "";
            _surname = "";
            _email = "";
            _date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Model = new UserInputModel(data);
            data.UserChosen += UserInfo;
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public UserInputModel Model { get; private set; }

        public ICommand ProcessCommand
        {
            get
            {
                if (_processCommand == null)
                    _processCommand = new RelayCommand(ExecuteProcess);
                return _processCommand;
            }
        }

        private void ExecuteProcess(object obj)
        {
            try
            {
                switch (EditMode)
                {
                    case UserEditMode.Add:
                        Model.AddUser(Name, Surname, Email, SelectedDate);
                        break;
                    case UserEditMode.Edit:
                        Model.EditUser(Model.ChosenUser, Name, Surname, Email, SelectedDate);
                        break;
                    default:
                        throw new NotImplementedException("This UserEditMode is still not implemented !");
                }

                if (Model.IsBirthDay())
                    MessageBox.Show("Happy Birthday!Let your all the dreams to be on fire and light your birthday candles with that. \nHave a gorgeous birthday!", "Birthday");
                NavigationManager.Instance.Navigate(Models.Views.UsersView);
            }
            catch (PersonException ex)
            {
                MessageBox.Show(ex.Message, "Error !");
            }
        }

        private void UserInfo(Person user)
        {
            if (user == null)
            {
                Name = "";
                Surname = "";
                Email = "";
                SelectedDate = DateTime.Now;
            }
            else
            {
                Name = user.Name;
                Surname = user.Surname;
                Email = user.Email;
                SelectedDate = user.BirthDate;
            }
        }
    }
}