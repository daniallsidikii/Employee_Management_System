using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Employee_Management_System
{
    // Class to represent a health record
    public class HealthRecord
    {
        public string? BloodPressure { get; set; } // Blood pressure value
        public string? Vision { get; set; } // Vision value
        public DateTime LastCheckup { get; set; } // Last checkup date
    }

    public partial class HealthRecordsWindow : Window
    {
        // File path for storing health records
        private readonly string healthRecordFile = "HealthRecord.json";

        // Constructor
        public HealthRecordsWindow()
        {
            InitializeComponent();
            ClearFields(); // Ensure fields are empty on startup
        }

        // Clear all fields
        private void ClearFields()
        {
            txtBloodPressure.Clear();
            txtVision.Clear();
            dpLastCheckup.SelectedDate = null;
        }

        // Load health records from file
        private void LoadHealthRecord()
        {
            if (File.Exists(healthRecordFile))
            {
                try
                {
                    // Read and deserialize the health record
                    string json = File.ReadAllText(healthRecordFile);
                    HealthRecord record = JsonConvert.DeserializeObject<HealthRecord>(json) ?? new HealthRecord();

                    // Refresh UI fields
                    txtBloodPressure.Text = record.BloodPressure ?? string.Empty;
                    txtVision.Text = record.Vision ?? string.Empty;
                    dpLastCheckup.SelectedDate = record.LastCheckup != DateTime.MinValue ? record.LastCheckup : (DateTime?)null;

                    MessageBox.Show("Health Records Loaded Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading health records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No health records found!", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Save health records to file
        private void SaveHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            if (dpLastCheckup.SelectedDate == null)
            {
                MessageBox.Show("Please select a valid checkup date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Create a new health record object
                HealthRecord record = new HealthRecord
                {
                    BloodPressure = txtBloodPressure.Text,
                    Vision = txtVision.Text,
                    LastCheckup = dpLastCheckup.SelectedDate.Value
                };

                // Serialize and save the health record to file
                File.WriteAllText(healthRecordFile, JsonConvert.SerializeObject(record, Formatting.Indented));
                MessageBox.Show("Health Record Saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving health records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Refresh health records by reloading from file
        private void LoadHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            LoadHealthRecord();
        }
    }
}