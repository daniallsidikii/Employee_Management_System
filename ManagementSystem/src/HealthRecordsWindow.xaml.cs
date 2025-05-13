using System;
using System.Data.SQLite;
using System.IO;
using System.Windows;

namespace Employee_Management_System
{
    // Class to represent a health record
    public class HealthRecord
    {
        public int Id { get; set; } // Primary Key for the database
        public string Username { get; set; } // To uniquely identify each user
        public string BloodPressure { get; set; }
        public string Vision { get; set; }
        public DateTime LastCheckup { get; set; }
    }

    public partial class HealthRecordsWindow : Window
    {
        private string userName; // User name to identify the current user

        // Constructor
        public HealthRecordsWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName; // Initialize userName
            CreateDatabase(); // Ensure the database and table are created
            ClearFields(); // Ensure fields are empty on startup
        }

        // Create SQLite database and table
        private void CreateDatabase()
        {
            string connectionString = "Data Source=healthRecords.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS HealthRecords (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                                                Username TEXT NOT NULL, 
                                                BloodPressure TEXT, 
                                                Vision TEXT, 
                                                LastCheckup DATE)";
                
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // Get the file path for storing health records (unique for each user)
        private string GetHealthRecordFile()
        {
            string folder = "HealthRecords";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return Path.Combine(folder, $"{userName}_HealthRecord.json");
        }

        // Clear all fields
        private void ClearFields()
        {
            txtBloodPressure.Clear();
            txtVision.Clear();
            dpLastCheckup.SelectedDate = null;
        }

        // Save health records to database
        private void SaveHealthRecordToDatabase()
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
                    Username = userName,  // Assuming the username is passed to the constructor
                    BloodPressure = txtBloodPressure.Text,
                    Vision = txtVision.Text,
                    LastCheckup = dpLastCheckup.SelectedDate.Value
                };

                string connectionString = "Data Source=healthRecords.db;Version=3;";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Prepare an SQL command to insert the record
                    string insertQuery = "INSERT INTO HealthRecords (Username, BloodPressure, Vision, LastCheckup) VALUES (@Username, @BloodPressure, @Vision, @LastCheckup)";

                    using (var command = new SQLiteCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Username", record.Username);
                        command.Parameters.AddWithValue("@BloodPressure", record.BloodPressure);
                        command.Parameters.AddWithValue("@Vision", record.Vision);
                        command.Parameters.AddWithValue("@LastCheckup", record.LastCheckup);

                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }

                MessageBox.Show("Health Record Saved!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving health record: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Load health record from database
        private void LoadHealthRecordFromDatabase()
        {
            string connectionString = "Data Source=healthRecords.db;Version=3;";
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Prepare the SQL query to load the health record by username
                string selectQuery = "SELECT BloodPressure, Vision, LastCheckup FROM HealthRecords WHERE Username = @Username LIMIT 1";

                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", userName);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtBloodPressure.Text = reader["BloodPressure"].ToString();
                            txtVision.Text = reader["Vision"].ToString();
                            dpLastCheckup.SelectedDate = reader["LastCheckup"] != DBNull.Value ? (DateTime?)reader["LastCheckup"] : null;

                            MessageBox.Show("Health Records Loaded Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("No health records found for this user.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                }

                connection.Close();
            }
        }

        // Save button click event handler
        private void SaveHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            SaveHealthRecordToDatabase();
        }

        // Load button click event handler
        private void LoadHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            LoadHealthRecordFromDatabase();
        }
    }
}
