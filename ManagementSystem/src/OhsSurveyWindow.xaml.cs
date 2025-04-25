using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Employee_Management_System
{
    public partial class OhsSurveyWindow : Window
    {
        private string userName; // User name to identify the current user

        // Constructor
        public OhsSurveyWindow(string userName)
        {
            InitializeComponent();
            this.userName = userName; // Initialize userName
        }

        // Get the file path for storing survey responses (unique for each user)
        private string GetSurveyFile() => $"{userName}_OHSSurveyResponses.json";

        // Event handler for submitting the survey
        private void SubmitSurvey_Click(object sender, RoutedEventArgs e)
        {
            // Validate that all questions are answered
            if (string.IsNullOrWhiteSpace(cmbHazards.Text) ||
                string.IsNullOrWhiteSpace(cmbBreaks.Text) ||
                string.IsNullOrWhiteSpace(cmbComfort.Text))
            {
                MessageBox.Show("Please answer all the questions before submitting the survey.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Create a response object with survey data
            var response = new
            {
                Date = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"),
                Hazards = cmbHazards.Text,
                Breaks = cmbBreaks.Text,
                Comfort = cmbComfort.Text
            };

            // Load existing survey responses or initialize a new list
            string surveyFile = GetSurveyFile();
            List<object> surveyResponses;
            if (File.Exists(surveyFile))
            {
                string json = File.ReadAllText(surveyFile);
                surveyResponses = JsonConvert.DeserializeObject<List<object>>(json) ?? new List<object>();
            }
            else
            {
                surveyResponses = new List<object>();
            }

            // Add the new response to the list
            surveyResponses.Add(response);

            // Save the updated list back to the file
            File.WriteAllText(surveyFile, JsonConvert.SerializeObject(surveyResponses, Formatting.Indented));

            // Show success message and close the window
            MessageBox.Show("Survey submitted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}