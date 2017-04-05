using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class Register : System.Web.UI.Page
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
                Response.Redirect("Register.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void Finish(object sender, EventArgs e)
    {
        if(!FirstName.Text.Equals("") && !LastName.Text.Equals("") && !Username.Text.Equals("") && !Email.Text.Equals("") 
            && !Password.Text.Equals("") && !ConfirmPassword.Text.Equals("") && ConfirmPassword.Text.Equals(Password.Text))
        {
            string passHash = Generate(Password.Text);
            try
            {
                SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("Emerald_Database");

                string command = "select count(user_userid) as countOfAccounts from USER_DATA;";
                SqlCommand sqlCommand = new SqlCommand(command, dbConnection);

                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());

                count++;

                string insertCommand = "Insert into user_data values (" + count + ",'" + Username.Text + "', '"
                    + FirstName.Text + "', '" + LastName.Text + "', '" + Email.Text + "', 0, 0, '" + passHash + "')";
                //Response.Write(command);
                sqlCommand.CommandText = insertCommand;
                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                dbConnection.Close();

                Response.Redirect("Home.aspx");
            }
            catch (Exception except)
            {
                Response.Write("Error! " + except);
            }
        }
        else if(!ConfirmPassword.Text.Equals(Password.Text))
        {
            ConfirmPasswordWrong.Text = "Password and Confirm Password do not match!!!<br />";
            ConfirmPasswordWrong.ForeColor = System.Drawing.Color.Red;
            ConfirmPasswordWrong.Visible = true;
        }
    }

    string Generate(string password)
    {
        //create salt value
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

        //create derive bytes and get hash value
        var pbfdk2 = new Rfc2898DeriveBytes(password, salt, 10000);
        byte[] hash = pbfdk2.GetBytes(20);

        //combine salt and password bytes
        byte[] hashBytes = new byte[36];
        Array.Copy(salt, 0, hashBytes, 0, 16);
        Array.Copy(hash, 0, hashBytes, 16, 20);

        //turn combined hash and salt into string for storage
        string savedPasswordHash = Convert.ToBase64String(hashBytes);

        return savedPasswordHash;
    }
}