using System.Windows;
using System.Windows.Controls;

namespace GPA_Calculator
{
    public partial class SelectionPage : Page
    {
        private string semesterNo;

        public SelectionPage(string semesterNo)
        {
            InitializeComponent();
            this.semesterNo = semesterNo;
        }
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
        private void GPA_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GPACalculate(semesterNo));
        }

        private void CGPA_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CGPACalculator());
        }
    }
}
