using System.Windows;
using System.Windows.Navigation;

namespace GPA_Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Start(MainFrame));
        }
    }
}
