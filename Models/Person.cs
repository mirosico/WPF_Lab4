using System;
using System.Linq;
using System.Text.RegularExpressions;
using Lab4_Mysko.Tools;

namespace Lab4_Mysko.Models
{
    [Serializable]
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDate = DateTime.Now;
        private const string correctEmail = "\\w+@\\w+\\.\\w+";

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
        }

        public Person(string name, string surname, string email, DateTime birthDate) : this(name, surname, email)
        {
            BirthDate = birthDate;
        }

        public Person(string name, string surname, DateTime birthDate)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
        }

        public string Name
        {
            get => _name;
            private set
            {
                if (value.Length == 0 || char.IsLower(value[0]))
                {
                    throw new NameException();
                }
                _name = value;
            }
        }

        public string Surname
        {
            get => _surname;
            private set
            {
                if (value.Length == 0 || char.IsLower(value[0]))
                {
                    throw new SurnameException();
                }
                _surname = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!Regex.IsMatch(value, correctEmail) || value.Contains(' '))
                {
                    throw new EmailException();
                }
                _email = value;
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                var days = (DateTime.Now - value).Days;
                if (days <= 0 || days / 365 > 135)
                {
                    throw new AgeException();
                }
                _birthDate = value;
                SunSign = CalculateSunSign(_birthDate);
                ChineseSign = CalculateChineseSign(_birthDate);
            }
        }

        public bool IsAdult
        {
            get
            {
                var age = DateTime.Now - _birthDate;
                return age.Days / 365 >= 18;
            }
        }
        public string SunSign { get; private set; }

        public string ChineseSign { get; private set; }

        public bool IsBirthday
        {
            get => _birthDate.Day == DateTime.Now.Day && _birthDate.Month == DateTime.Now.Month;
        }
        private string CalculateSunSign(DateTime date)
        {
            int month = date.Month;
            int day = date.Day;
            switch (month)
            {
                case 1:
                    return day <= 20 ? "Capricorn" : "Aquarius";
                case 2:
                    return day <= 19 ? "Aquarius" : "Pisces";
                case 3:
                    return day <= 20 ? "Pisces" : "Aries";
                case 4:
                    return day <= 20 ? "Aries" : "Taurus";
                case 5:
                    return day <= 21 ? "Taurus" : "Gemini";
                case 6:
                    return day <= 22 ? "Gemini" : "Cancer";
                case 7:
                    return day <= 22 ? "Cancer" : "Leo";
                case 8:
                    return day <= 23 ? "Leo" : "Virgo";
                case 9:
                    return day <= 23 ? "Virgo" : "Libra";
                case 10:
                    return day <= 23 ? "Libra" : "Scorpio";
                case 11:
                    return day <= 22 ? "Scorpio" : "Sagittarius";
                case 12:
                    return day <= 21 ? "Sagittarius" : "Capricorn";
                default:
                    throw new ArgumentException("Inappropriate format of month !");
            }
        }
        private string CalculateChineseSign(DateTime date)
        {
            int year = date.Year;
            int chinese = (year - 4) % 12;
            switch (chinese)
            {
                case 0:
                    return "Rat";
                case 1:
                    return "Ox";
                case 2:
                    return "Tiger";
                case 3:
                    return "Rabbit";
                case 4:
                    return "Dragon";
                case 5:
                    return "Snake";
                case 6:
                    return "Horse";
                case 7:
                    return "Goat";
                case 8:
                    return "Monkey";
                case 9:
                    return "Rooster";
                case 10:
                    return "Dog";
                case 11:
                    return "Pig";
                default:
                    throw new ArgumentException("Inappropriate format of year!");
            }
        }
    }
}