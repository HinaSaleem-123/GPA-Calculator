
using System.Windows;
using System.Windows.Controls;

namespace GPA_Calculator
{
    public partial class CGPACalculator : Page
    {
        public CGPACalculator()
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
        private void GenerateFields_Click(object sender, RoutedEventArgs e)
        {
            GPAInputsPanel.Children.Clear();
            if (int.TryParse(SemesterCountBox.Text, out int count) && count > 0)
            {
                for (int i = 1; i <= count; i++)
                {
                    StackPanel row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };
                    row.Children.Add(new TextBlock { Text = $"Semester {i} GPA:", Width = 120, VerticalAlignment = VerticalAlignment.Center });
                    row.Children.Add(new TextBox { Width = 100, Name = $"GPABox{i}" });
                    GPAInputsPanel.Children.Add(row);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid number of semesters.","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void CalculateCGPA_Click(object sender, RoutedEventArgs e)
        {
            double totalGPA = 0;
            int count = GPAInputsPanel.Children.Count;

            for (int i = 0; i < count; i++)
            {
                var row = GPAInputsPanel.Children[i] as StackPanel;
                var textbox = row?.Children[1] as TextBox;

                if (textbox != null && double.TryParse(textbox.Text, out double gpa))
                {
                    totalGPA += gpa;
                }
                else
                {
                    MessageBox.Show($"Invalid GPA input for semester {i + 1}","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(SemesterCountBox.Text))
            {
                MessageBox.Show("Please enter semester number", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            double cgpa = totalGPA / count;
            ResultTextBlock.Text = $"Your CGPA is: {cgpa:F2}";
        }
    }
}
