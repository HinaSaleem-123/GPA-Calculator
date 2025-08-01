using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using GPA_Calculator;

namespace GPA_Calculator
{
    public partial class Start : Page
    {
        private Frame _mainFrame;

        public Start(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void StartCalculating_Click(object sender, RoutedEventArgs e)
        {
            string semesterNum = SemesterTextBox.Text.Trim();
            if (string.IsNullOrEmpty(semesterNum))
            {
                MessageBox.Show("Please enter a semester number.","warning", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                return;
            }
            if (!int.TryParse(semesterNum, out int semesterNumber))
            {
                MessageBox.Show("Semester must be a number between 1 and 8.");
                return;
            }

            

            this.NavigationService.Navigate(new SelectionPage(semesterNum));
        }

        
        private void GradeSheet_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GradeSheet());
        }
    }
}
