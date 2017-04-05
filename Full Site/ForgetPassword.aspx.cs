using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UsernameSubmit(object sender, EventArgs e)
    {
        SqlDataReader reader = null;
        SqlConnection con = new SqlConnection("Data Source=stusql;Initial Catalog=Emerald_Database; Integrated Security=true");
        {
            con.Open();

            SqlCommand com = new SqlCommand("Select user_userid, USER_USERNAME, USER_FNAME, USER_LNAME, USER_EMAIL_ADDRESS FROM USER_DATA WHERE USER_USERNAME= '" + UserText.Text + "'", con);
            reader = com.ExecuteReader();

            if (reader.Read())
            {
                if(reader["USER_USERNAME"].Equals(UserText.Text) && reader["USER_FNAME"].Equals(FirstText.Text) && reader["USER_LNAME"].Equals(LastText.Text)
                     && reader["USER_EMAIL_ADDRESS"].Equals(EmailText.Text))
                {
                    Response.Redirect("NewPassword.aspx?id=" + reader["user_userid"]);
                }
            }

            else
            {
                lblMessage.Text = "This username does not exist."; 
            }
        }
    }
}