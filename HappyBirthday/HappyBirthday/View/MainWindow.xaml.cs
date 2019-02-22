using System.Windows;
using HappyBirthday.ViewModel;

namespace HappyBirthday.View
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }
        
    }
}
