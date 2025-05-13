using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data.SQLite;
using Employee_Management_System.Models; // Assuming HealthRecordDisplay is in the Models folder

namespace Employee_Management_System
{
    public partial class AdminHealthWindow : Window
    {
        private const string connectionString = "Data Source=healthrecords.db;Version=3;"; // Change database path if needed

        public AdminHealthWindow()
        {
            InitializeComponent();
            LoadAllHealthRecords();
        }

        // Method to load all health records from the database
        private void LoadAllHealthRecords()
        {
            List<HealthRecordDisplay> records = new List<HealthRecordDisplay>();

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Username, BloodPressure, Vision, LastCheckup FROM HealthRecords ORDER BY LastCheckup DESC";
                    SQLiteCommand cmd = new SQLiteCommand(query, conn);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            records.Add(new HealthRecordDisplay
                            {
                                Username = reader["Username"].ToString(),
                                BloodPressure = reader["BloodPressure"].ToString(),
                                Vision = reader["Vision"].ToString(),
                                LastCheckup = Convert.ToDateTime(reader["LastCheckup"])
                            });
                        }
                    }
                }

                HealthGrid.ItemsSource = records;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading health records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to refresh health records
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAllHealthRecords();
        }

        // Method to close the window
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
