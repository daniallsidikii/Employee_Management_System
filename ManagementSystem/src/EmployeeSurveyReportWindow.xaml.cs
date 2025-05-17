// EmployeeSurveyReportWindow.xaml.cs
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SQLite;
using System.Collections.Generic;


namespace Employee_Management_System
{
    public partial class EmployeeSurveyReportWindow : Window
    {
        private string dbPath = "Data Source=employees.db";

        public class SurveyResponse
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }

        public EmployeeSurveyReportWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string employeeId = txtEmployeeId.Text.Trim();
            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Please enter an Employee ID", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();

                    // Get the most recent survey for this employee
                    string query = @"
                    SELECT * FROM OhsSurveyResponses 
                    WHERE UserName = @UserName
                    ORDER BY DateSubmitted DESC
                    LIMIT 1";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", employeeId);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Display employee info
                                txtEmployeeName.Text = $"{reader["UserName"]}";
                                txtSurveyDate.Text = $"{DateTime.Parse(reader["DateSubmitted"].ToString()).ToString("yyyy-MM-dd")}";

                                // Load survey responses
                                var responses = new List<SurveyResponse>
                                {
                                    new SurveyResponse { Question = "1. Experienced workplace hazards?", Answer = reader["Hazards"].ToString() },
                                    new SurveyResponse { Question = "2. Frequency of breaks?", Answer = reader["Breaks"].ToString() },
                                    new SurveyResponse { Question = "3. Comfortable in workspace?", Answer = reader["Comfort"].ToString() },
                                    new SurveyResponse { Question = "4. Ergonomic issues?", Answer = reader["Ergonomics"].ToString() },
                                    new SurveyResponse { Question = "5. Adequate safety measures?", Answer = reader["Safety"].ToString() },
                                    new SurveyResponse { Question = "6. Received safety training?", Answer = reader["Training"].ToString() },
                                    new SurveyResponse { Question = "7. Work stress levels?", Answer = reader["Stress"].ToString() },
                                    new SurveyResponse { Question = "8. Emergency exits accessible?", Answer = reader["Emergency"].ToString() },
                                    new SurveyResponse { Question = "9. Hygiene concerns?", Answer = reader["Hygiene"].ToString() }
                                };

                                surveyResults.ItemsSource = responses;
                                txtEmployeeSuggestions.Text = reader["Suggestions"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No survey found for this employee", "Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving survey: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void txtEmployeeId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Search_Click(sender, e);
            }
        }
    }
}