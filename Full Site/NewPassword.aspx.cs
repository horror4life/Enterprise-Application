using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void PasswordSubmit(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (ConfirmPassword.Text.Equals(NewPassword.Text))
        {
            string passHash = Generate(NewPassword.Text);
            try
            {
                if (id != null)
                {
                    SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
                    dbConnection.Open();
                    dbConnection.ChangeDatabase("Emerald_Database");
                    string command = "update user_data set user_hash='" + passHash + "' where user_userid=" + id;
                    SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
                    sqlCommand.ExecuteScalar();

                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("Error!");
                }
            }
            catch
            {
                Response.Write("Error!");
            }
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