using HappyBirthday.Tools;
using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace HappyBirthday.ViewModel
{
    internal class BirthdayPickerViewModel : BaseViewModel
    {
       

        private RelayCommand<object> _checkDate;


        private DateTime _birthday = DateTime.Today;
        private string _age;
        private string _happyBirthday;
        private string _westZodiacSign;
        private string _chineseZodiacSign;

        private static readonly string[] ChineseZodiacSings = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string BirthdayMessage
        {
            get => _happyBirthday;
            set
            {
                _happyBirthday = value;
                OnPropertyChanged();
            }
        }

        public string WestZodiacSign
        {
            get => _westZodiacSign;
            set
            {
                _westZodiacSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiacSign
        {
            get => _chineseZodiacSign;
            set
            {
                _chineseZodiacSign = value;
                OnPropertyChanged();
            }
        }

      
        public RelayCommand<object> CheckDate =>
            _checkDate ?? (_checkDate = new RelayCommand<object>(
                CheckDateClick));

   

        private async void CheckDateClick(object obj)
        {
            BirthdayMessage = "";
            Age = "";
            ChineseZodiacSign = "";
            WestZodiacSign = "";

            LoaderManager.Instance.ShowLoader();

            await Task.Run(() => Thread.Sleep(1000));

            LoaderManager.Instance.HideLoader();

            if (!IsDateCorrect(Birthday))
            {
                MessageBox.Show("Date"+ Birthday.ToShortDateString()+ " is incorrect. Try again.");
                return;
            }

            Age = "Your Age: " + CalculateAge(Birthday);

            BirthdayMessage = HasBirthdayToday(Birthday) ? "Is it your birthday? : Yes, HAPPY BIRTHDAY!" : "Is it your birthday? : No, wait for your birthday for congrats";

            WestZodiacSign = "Your west zodiac sign is: " + CalculateWestZodiacSign(Birthday);

            ChineseZodiacSign = "Your chinese zodiac sign is: " + ChineseZodiacSings[(Birthday.Year - 4) % 12];
        }

       

        private static bool IsDateCorrect(DateTime date)
        {
            return  date.Year > 1890 && date.CompareTo(DateTime.Today) <= 0 ;
        }

        private static int CalculateAge(DateTime date)
        {
            var age = DateTime.Today.Year - date.Year;
            if (DateTime.Today < date.AddYears(age)) age--;
            return age;
        }

        private static bool HasBirthdayToday(DateTime date)
        {
            return date.Month == DateTime.Today.Month && date.Day == DateTime.Today.Day;
        }

        private static string CalculateWestZodiacSign(DateTime date)
        {
            switch (date.Month)
            {
                case 12 when (date.Day >= 22 && date.Day <= 31):
                case 1 when (date.Day >= 1 && date.Day <= 19):
                    return "Capricorn";
                case 1 when (date.Day >= 20 && date.Day <= 31):
                case 2 when (date.Day >= 1 && date.Day <= 17):
                    return ("Aquarius");
                case 2 when (date.Day >= 18 && date.Day <= 29):
                case 3 when (date.Day >= 1 && date.Day <= 19):
                    return ("Pisces");
                case 3 when (date.Day >= 20 && date.Day <= 31):
                case 4 when (date.Day >= 1 && date.Day <= 19):
                    return ("Aries");
                case 4 when (date.Day >= 20 && date.Day <= 30):
                case 5 when (date.Day >= 1 && date.Day <= 20):
                    return ("Taurus");
                case 5 when (date.Day >= 21 && date.Day <= 31):
                case 6 when (date.Day >= 1 && date.Day <= 20):
                    return ("Gemini");
                case 6 when (date.Day >= 21 && date.Day <= 30):
                case 7 when (date.Day >= 1 && date.Day <= 22):
                    return ("Cancer");
                case 7 when (date.Day >= 23 && date.Day <= 31):
                case 8 when (date.Day >= 1 && date.Day <= 22):
                    return ("Leo");
                case 8 when (date.Day >= 23 && date.Day <= 31):
                case 9 when (date.Day >= 1 && date.Day <= 22):
                    return ("Virgo");
                case 9 when (date.Day >= 23 && date.Day <= 30):
                case 10 when (date.Day >= 1 && date.Day <= 22):
                    return ("Libra");
                case 10 when (date.Day >= 23 && date.Day <= 31):
                case 11 when (date.Day >= 1 && date.Day <= 21):
                    return ("Scorpio");
                case 11 when (date.Day >= 22 && date.Day <= 30):
                case 12 when (date.Day >= 1 && date.Day <= 21):
                    return ("Sagittarius");
                default: return "Wrong";
            }
        }

    }
}