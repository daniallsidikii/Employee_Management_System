using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace Employee_Management_System
{
    public partial class OhsSurveyWindow : Window
    {
        private string userName;
        private string dbPath = "Data Source=employees.db";

        public OhsSurveyWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        } 

        private void SubmitSurvey_Click(object sender, RoutedEventArgs e)
        {
            // Validate all ComboBoxes are selected
            if (cmbHazards.SelectedItem == null ||
                cmbBreaks.SelectedItem == null ||
                cmbComfort.SelectedItem == null ||
                cmbErgonomics.SelectedItem == null ||
                cmbSafety.SelectedItem == null ||
                cmbTraining.SelectedItem == null ||
                cmbStress.SelectedItem == null ||
                cmbEmergency.SelectedItem == null ||
                cmbHygiene.SelectedItem == null)
            {
                MessageBox.Show("Please answer all the questions before submitting.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();

                    string insertQuery = @"
                    INSERT INTO OhsSurveyResponses 
                    (UserName, DateSubmitted, Hazards, Breaks, Comfort, Ergonomics, Safety, Training, Stress, Emergency, Hygiene, Suggestions) 
                    VALUES 
                    (@UserName, @DateSubmitted, @Hazards, @Breaks, @Comfort, @Ergonomics, @Safety, @Training, @Stress, @Emergency, @Hygiene, @Suggestions);";

                    using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@DateSubmitted", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@Hazards", (cmbHazards.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Breaks", (cmbBreaks.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Comfort", (cmbComfort.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Ergonomics", (cmbErgonomics.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Safety", (cmbSafety.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Training", (cmbTraining.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Stress", (cmbStress.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Emergency", (cmbEmergency.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Hygiene", (cmbHygiene.SelectedItem as ComboBoxItem).Content.ToString());
                        cmd.Parameters.AddWithValue("@Suggestions", txtSuggestions.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                MessageBox.Show("Survey submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
