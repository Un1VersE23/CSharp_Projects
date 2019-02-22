
using System.Windows.Controls;
using HappyBirthday.ViewModel;


namespace HappyBirthday.View
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for BirthdayPicker.xaml
    /// </summary>
    public partial class BirthdayPicker : UserControl
    {
        public BirthdayPicker()
        {
            InitializeComponent();
            DataContext = new BirthdayPickerViewModel();
        }
    }
}
