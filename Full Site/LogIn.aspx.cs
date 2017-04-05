using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("Emerald_Database");
                string command = "update user_data set is_user_loggedin=0 where user_userid=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
                sqlCommand.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void logIn(object sender, EventArgs e)
    {
        try
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
            dbConnection.Open();
            dbConnection.ChangeDatabase("Emerald_Database");
            string command = "select user_userid, user_email_address from user_data where user_email_address='" + email.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
            SqlDataReader records = sqlCommand.ExecuteReader();

            if (records.Read())
            {
                bool checkIfPass = check();
                if (checkIfPass)
                {
                    string url = "Home.aspx?Id=" + records["user_userid"];
                    records.Close();
                    string updateCommand = "update user_data set is_user_loggedin=1 where user_email_address='" + email.Text + "'";
                    sqlCommand.CommandText = updateCommand;
                    sqlCommand.ExecuteNonQuery();
                    Response.Redirect(url);
                }
            }
            else if (!records.Read())
            {
                WrongInformation.Text = "**The information you entered is incorrect!**<br/>";
                WrongInformation.ForeColor = System.Drawing.Color.Red;
                WrongInformation.Visible = true;
            }
        }
        catch
        {
            Response.Write("ERROR!!!");
        }
    }

    bool check()
    {
        try
        {
            SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
            dbConnection.Open();
            dbConnection.ChangeDatabase("Emerald_Database");
            string command = "select user_hash from user_data where USER_EMAIL_ADDRESS = '" + email.Text + "'";
            SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
            string savedPasswordHash = sqlCommand.ExecuteScalar().ToString();

            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf3 = new Rfc2898DeriveBytes(password.Text, salt, 10000);
            byte[] hash = pbkdf3.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
        }
        catch
        {
            return false;
        }
        return true;
    }
}