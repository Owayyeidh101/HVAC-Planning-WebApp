using System;

namespace HVAC_Planning_WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["LoggedInUser"] != null)
            {
                string loggedInUser = Session["LoggedInUser"].ToString();
                WelcomeLabel.Text = $"Welcome, {loggedInUser}!";
            }
            else
            {
                // Redirect to the login page if not logged in
                Response.Redirect("Login.aspx");
            }
        }
    }
}
