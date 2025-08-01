using System.Windows;
using System.Windows.Controls;


namespace GPA_Calculator
{
    public partial class GradeSheet : Page
    {
        public GradeSheet()
        {
            InitializeComponent();
        }
        private void NavigateButton_Click(object sender, RoutedEventArgs e)
{
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

    }
}
