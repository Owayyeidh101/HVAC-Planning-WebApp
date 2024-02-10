using System;
using System.Configuration;
using System.Data.SqlClient;

namespace HVAC_Planning_WebApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page load logic, if needed
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Validate that textboxes are not empty
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                SetStatusLabel("Please enter both username and password.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["Str1"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("AuthenticateUser", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Get values from the textboxes
                    string username = TextBox1.Text.Trim();
                    string password = TextBox2.Text.Trim();

                    // Add parameters
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@UserPassword", password);

                    // Output parameter to get the authentication result
                    SqlParameter outputParameter = new SqlParameter("@AuthenticationResult", System.Data.SqlDbType.Int);
                    outputParameter.Direction = System.Data.ParameterDirection.Output;
                    command.Parameters.Add(outputParameter);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        int authenticationResult = Convert.ToInt32(outputParameter.Value);

                        if (authenticationResult == 1)
                        {
                            // Authentication successful
                            SetStatusLabel("Login successful.");

                            // Store the logged-in user in a session variable
                            Session["LoggedInUser"] = username;

                            // Redirect to the home page
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            // Authentication failed
                            SetStatusLabel("Login failed. Invalid username or password.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        SetStatusLabel("Error during login: " + ex.Message);
                    }
                }
            }
        }

        // Helper method to set the text of the status label
        private void SetStatusLabel(string message)
        {
            StatusLabel.Text = message;
        }
    }
}
