using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace Employee_Management_System
{
    public partial class AdminHealthWindow : Window
    {
        public AdminHealthWindow()
        {
            InitializeComponent();
            LoadAllHealthRecords();
        }

        private void LoadAllHealthRecords()
        {
            string healthFolder = "HealthRecords";
            List<HealthRecordDisplay> records = new List<HealthRecordDisplay>();

            if (!Directory.Exists(healthFolder))
            {
                Directory.CreateDirectory(healthFolder);
                MessageBox.Show("HealthRecords folder was missing and has been created. Please add health records.");
                return;
            }

            foreach (var file in Directory.GetFiles(healthFolder, "*_HealthRecord.json"))
            {
                string username = Path.GetFileNameWithoutExtension(file).Replace("_HealthRecord", "");

                try
                {
                    string json = File.ReadAllText(file);
                    var record = JsonConvert.DeserializeObject<HealthRecordDisplay>(json);

                    if (record != null)
                    {
                        record.Username = username;
                        records.Add(record);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to read {file}:\n{ex.Message}");
                }
            }

            HealthGrid.ItemsSource = records.OrderByDescending(r => r.LastCheckup).ToList();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadAllHealthRecords();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
