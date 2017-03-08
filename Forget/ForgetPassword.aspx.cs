using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void UsernameSubmit(object sender, EventArgs e)
    {
        SqlDataReader reader = null;
        SqlConnection con = new SqlConnection("Data Source=stusql;Initial Catalog=Emerald_Studios; Integrated Security=true");
        {
            con.Open();

            SqlCommand com = new SqlCommand("Select USER_USERNAME, USER_FNAME, USER_LNAME, USER_EMAIL_ADDRESS FROM USER_DATA WHERE USER_NAME = @username", con);
            com.Parameters.AddWithValue("@username", UserText.Text);
            reader = com.ExecuteReader();

            if (reader.Read())
            {
                if(reader["USER_USERNAME"].Equals(UserText.Text) && reader["USER_FNAME"].Equals(FirstText.Text) && reader["USER_LNAME"].Equals(LastText.Text)
                     && reader["USER_EMAIL_ADDRESS"].Equals(EmailText.Text))
                {
                    Response.Redirect("NewPassword.aspx");
                }
            }

            else
            {
                lblMessage.Text = "This username does not exist."; 
            }
        }
    }
}