using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void PassswordSumbit(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("Data Source=stusql;Initial Catalog=Emerald_Studios; Integrated Security=true");
        {
            con.Open();

            if (NewPassword.Text.Equals(ConfirmPassword.Text))
            {
                SqlCommand com = new SqlCommand("UPDATE USER_DATA SET USER_PASSWORD = @userpassword", con);
                com.Parameters.AddWithValue("@userpassword", ConfirmPassword.Text);

                SqlCommand com2 = new SqlCommand("UPDATE USER_DATA SET IS_USER_LOGGEDIN = 0");
                Response.Redirect("Login.aspx");
            }
        }
    }
}