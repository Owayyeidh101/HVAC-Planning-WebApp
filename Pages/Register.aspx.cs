using System;
using System.Configuration;
using System.Data.SqlClient;

namespace HVAC_Planning_WebApp.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic, if needed
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            // Validate that textboxes are not empty
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) || string.IsNullOrWhiteSpace(TextBox3.Text))
            {
                SetStatusLabel("Please fill in all the fields.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Str1"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Get values from the textboxes
                    string username = TextBox1.Text.Trim();
                    string password = TextBox2.Text.Trim();
                    string email = TextBox3.Text.Trim();

                    // Validate email format
                    if (!IsValidEmail(email))
                    {
                        SetStatusLabel("Please enter a valid email address.");
                        return;
                    }

                    // Add parameters
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@UserPassword", password);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        // Registration successful
                        SetStatusLabel("Registration successful.");
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        SetStatusLabel("Error during registration: " + ex.Message);
                    }
                }
            }
        }

        // Validate email format using a simple regex
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Helper method to set the text of the status label
        private void SetStatusLabel(string message)
        {
            StatusLabel.Text = message;
        }
    }
}
