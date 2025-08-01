using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GPA_Calculator
{
    public partial class GPACalculate : Page
    {
        public GPACalculate(string semesterNo)
        {
            InitializeComponent();

            SemesterNumberTextBlock.Text = semesterNo;
        }

        private void NavigateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
       
        private WrapPanel CreateCourseRow()
        {
            WrapPanel row = new()
            {
                Margin = new Thickness(40, 0, 0, 0)
            };

            TextBox courseName = new()
            {
                Width = 170,
                Margin = new Thickness(0, 10, 20, 0),
                Foreground = new SolidColorBrush(Colors.Teal)
            };

            ComboBox grade = new()
            {
                Width = 70,
                Margin = new Thickness(0, 10, 20, 0),
                Foreground = new SolidColorBrush(Colors.Teal),
                SelectedIndex = 0
            };

            grade.Items.Add(new ComboBoxItem { Content = "A+" });
            grade.Items.Add(new ComboBoxItem { Content = "A" });
            grade.Items.Add(new ComboBoxItem { Content = "B+" });
            grade.Items.Add(new ComboBoxItem { Content = "B" });
            grade.Items.Add(new ComboBoxItem { Content = "B-" });
            grade.Items.Add(new ComboBoxItem { Content = "C+" });
            grade.Items.Add(new ComboBoxItem { Content = "C" });
            grade.Items.Add(new ComboBoxItem { Content = "C-" });
            grade.Items.Add(new ComboBoxItem { Content = "D+" });
            grade.Items.Add(new ComboBoxItem { Content = "D" });
            grade.Items.Add(new ComboBoxItem { Content = "F" });

            TextBox credits = new()
            {
                Width = 80,
                Margin = new Thickness(0, 10, 20, 0),
                Foreground = new SolidColorBrush(Colors.Teal)
            };

            row.Children.Add(courseName);
            row.Children.Add(grade);
            row.Children.Add(credits);

            return row;
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (CourseStackPanel != null)
            {
                CourseStackPanel.Children.Add(CreateCourseRow());
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            while (CourseStackPanel.Children.Count > 1)
            {
                CourseStackPanel.Children.RemoveAt(1);
            }

            if (CourseStackPanel.Children[0] is WrapPanel defaultRow)
            {
                foreach (var child in defaultRow.Children)
                {
                    if (child is TextBox textBox)
                        textBox.Text = string.Empty;

                    if (child is ComboBox comboBox)
                        comboBox.SelectedIndex = 0;
                }
            }

            GpaResultTextBlock.Text = string.Empty;
        }

        private void CalculateGPA_Click(object sender, RoutedEventArgs e)
        {
            double totalPoints = 0;
            double totalCredits = 0;

            foreach (var child in CourseStackPanel.Children)
            {
                if (child is WrapPanel row)
                {
                    string grade = string.Empty;
                    double credits = 0;

                    foreach (var control in row.Children)
                    {
                        if (control is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedGrade)
                        {
                            grade = selectedGrade.Content.ToString();
                        }
                        else if (control is TextBox textBox && double.TryParse(textBox.Text, out double creditVal))
                        {
                            credits = creditVal;
                        }
                    }

                    double gradePoints = GradeToPoints(grade);
                    totalPoints += gradePoints * credits;
                    totalCredits += credits;
                }
            }

            if (totalCredits > 0)
            {
                double gpa = totalPoints / totalCredits;
                GpaResultTextBlock.Text = $"Your GPA is: {gpa:F2}";
            }
            else
            {
                MessageBox.Show("Please enter valid credit values.","warning", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private double GradeToPoints(string grade)
        {
            return grade switch
            {
                "A+" => 4.00,
                "A" => 3.66,
                "B+" => 3.33,
                "B" => 3.00,
                "B-" => 2.66,
                "C+" => 2.33,
                "C" => 2.00,
                "C-" => 1.66,
                "D+" => 1.33,
                "D" => 1.00,
                "F" => 0.00,
                _ => 0.00
            };
        }
    }
}
