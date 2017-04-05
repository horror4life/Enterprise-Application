using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Log.HRef = "Account.aspx?id=" +id;
                Log.InnerText = "My Account";
                Reg.HRef = "Home.aspx";
                Reg.InnerText = "Log Out";
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void BrowseRedirect(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("Browse.aspx?id=" +id);
            }
            else
            {
                Response.Redirect("Browse.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void HomeRedirect(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("Home.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void AboutRedirect(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        try
        {
            if (id != null)
            {
                Response.Redirect("About.aspx?id=" + id);
            }
            else
            {
                Response.Redirect("About.aspx");
            }
        }
        catch
        {
            Response.Write("Error");
        }
    }

    protected void check(object sender, EventArgs e)
    {
        string id = Request.QueryString["Id"];
        if (id != null)
        {
            if (Reg.InnerText.Equals("Log Out"))
            {
                SqlConnection dbConnection = new SqlConnection("Data Source=stusql;Integrated Security=true");
                dbConnection.Open();
                dbConnection.ChangeDatabase("Emerald_Database");
                string command = "update user_data set is_user_loggedin = 0 where user_userid=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, dbConnection);
                sqlCommand.ExecuteNonQuery();
                dbConnection.Close();
                Response.Redirect("Home.aspx");
            }
        }
        else
        {
            Response.Redirect("Register.aspx");
        }
    }
}