using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Employee_Management_System
{
    public partial class HealthRecordsWindow : Window
    {
        public HealthRecordsWindow()
        {
            InitializeComponent();
        }

        // Event handler for the Save button click event
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Validate Inputs
            if (!ValidateInputs())
            {
                return;
            }

            // Save Data
            SaveHealthRecords();

            // Notify User
            MessageBox.Show("Health records saved successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        // Validate the inputs to ensure they are correctly filled
        private bool ValidateInputs()
        {
            // Ensure user didn't leave placeholders as input
            if (string.IsNullOrWhiteSpace(txtBloodPressure.Text) || txtBloodPressure.Text == "e.g., 120/80" ||
                string.IsNullOrWhiteSpace(txtVision.Text) || txtVision.Text == "e.g., 20/20" ||
                string.IsNullOrWhiteSpace(txtLastCheckup.Text) || txtLastCheckup.Text == "YYYY-MM-DD")
            {
                MessageBox.Show("Please fill in all fields correctly.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Validate date format
            if (!DateTime.TryParse(txtLastCheckup.Text, out _))
            {
                MessageBox.Show("Please enter a valid date (YYYY-MM-DD) for the Last Checkup.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        // Save the health records to a file
        private void SaveHealthRecords()
        {
            string record = $"Blood Pressure: {txtBloodPressure.Text}, Vision: {txtVision.Text}, Last Checkup: {txtLastCheckup.Text}, Date Recorded: {DateTime.Now}\n";
            File.AppendAllText("HealthRecords.txt", record);
        }

        // Event handler for the TextBox GotFocus event
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                // Clear placeholder text when the TextBox gains focus
                if (textBox.Text == "e.g., 120/80" || textBox.Text == "e.g., 20/20" || textBox.Text == "YYYY-MM-DD")
                {
                    textBox.Text = "";
                    textBox.Foreground = Brushes.Black;
                }
            }
        }

        // Event handler for the TextBox LostFocus event
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                // Restore placeholder text if the TextBox is empty when it loses focus
                if (textBox == txtBloodPressure)
                    textBox.Text = "e.g., 120/80";
                else if (textBox == txtVision)
                    textBox.Text = "e.g., 20/20";
                else if (textBox == txtLastCheckup)
                    textBox.Text = "YYYY-MM-DD";

                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}